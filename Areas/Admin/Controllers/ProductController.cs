using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Admin.Services;
using OnlineShop.Data;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private static HashSet<int> CategoryIds = new HashSet<int>();
        
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET
        [HttpGet]
        public IActionResult Products()
        {
            //string userType = HttpContext.User.Claims.Where(c => c.Type == "userType").First().Value;
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }

            IEnumerable<Product> products = _db.Products.OrderByDescending(p => p.Rate).ToList();
            List<ProductVM> productViews = new List<ProductVM>();
            
            foreach (var product in products)
            {
                ProductVM productVm = new ProductVM(product);
                productVm.Category = new CategoryVM(_db.Categories.Find(product.CategoryId));
                productViews.Add(productVm);
            }
            IEnumerable<Category> categories = _db.Categories.ToList();
            List<CategoryVM> categoryViews = new List<CategoryVM>();
            foreach (var category in categories)
            {
                CategoryVM categoryVm = new CategoryVM(category);
                categoryViews.Add(categoryVm);
            }
            
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = productViews;
            productPageModel.Categories = categoryViews;
            productPageModel.searchWord = "";
            return View(productPageModel);
        }
        
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            ProductVM model;
            Product dto = _db.Products.Find(id);
            if (dto == null)
            {
                return Content("This page does not exist.");
            }

            model = new ProductVM(dto);
            model.Category = new CategoryVM(_db.Categories.Find(dto.CategoryId));
            return View(model);
        }
        
        [HttpPost]
        public IActionResult EditProduct(ProductVM model)
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "You are not allowed to send post requests here.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_db.Categories.Where(c => c.Name.ToLower() == model.Category.Name.ToLower()).Any())
            {
                List<Category> categories = _db.Categories.ToList();
                string categoryNames = "";
                foreach (var category in categories)
                {
                    categoryNames += category.Name + ", ";
                }

                categoryNames = categoryNames.Substring(0, categoryNames.Length - 2);
                ModelState.AddModelError("", "This category does not exist. Categories available: " + categoryNames);
                return View(model);
            }

            Product dto = _db.Products.Find(model.Id);
            Category newCategoryDto = _db.Categories.Where(c => c.Name.ToLower() == model.Category.Name.ToLower()).First();
            
            dto.UpdateByModel(model);
            dto.CategoryId = newCategoryDto.Id;
            _db.Update(dto);
            _db.SaveChanges();
            // send successful message
            TempData["PSM"] = "You have updated " + dto.Name + " product.";
            return RedirectToAction("Products");
        }
        [HttpPost]
        public IActionResult Products(string searchWord)
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "You are not allowed to send post requests here.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            if (String.IsNullOrEmpty(searchWord))
            {
                return RedirectToAction("Products");
            }

            IEnumerable<Product> products = _db.Products
                .Where(p => p.Name.ToLower().Contains(searchWord.ToLower()) && (CategoryIds.Contains(p.CategoryId) || CategoryIds.Count() == 0))
                .OrderBy(p => p.Rate)
                .ToList();

            List<ProductVM> productViews = new List<ProductVM>();
            
            foreach (var product in products)
            {
                ProductVM productVm = new ProductVM(product);
                productVm.Category = new CategoryVM(_db.Categories.Find(product.CategoryId));
                productViews.Add(productVm);
            }
            IEnumerable<Category> categories = _db.Categories.ToList();
            List<CategoryVM> categoryViews = new List<CategoryVM>();
            foreach (var category in categories)
            {
                CategoryVM categoryVm = new CategoryVM(category);
                if (CategoryIds.Contains(category.Id))
                {
                    categoryVm.IsChecked = true;
                }

                categoryViews.Add(categoryVm);
            }
            
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = productViews;
            productPageModel.Categories = categoryViews;
            if (products.Count() == 0)
            {
                ModelState.AddModelError("", "Product not found.");
                return View(productPageModel);
            }
            return View("Products", productPageModel);
        }
        
        [HttpGet]
        public IActionResult ProductsByCategories(int categoryId)
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            if (!CategoryIds.Contains(categoryId))
            {
                CategoryIds.Add(categoryId);
            }
            else
            {
                CategoryIds.Remove(categoryId);
            }

            if (CategoryIds.Count() == 0)
            {
                return RedirectToAction("Products");
            }

            List<Product> products = _db.Products.Where(p => CategoryIds.Contains(p.CategoryId)).OrderBy(p => p.Rate).ToList();
            List<ProductVM> productViews = new List<ProductVM>();
            foreach (var product in products)
            {
                ProductVM productVm = new ProductVM(product);
                productVm.Category = new CategoryVM(_db.Categories.Find(product.CategoryId));
                productViews.Add(productVm);
            }

            IEnumerable<Category> categories = _db.Categories.ToList();
            List<CategoryVM> categoryViews = new List<CategoryVM>();
            foreach (var category in categories)
            {
                CategoryVM categoryVm = new CategoryVM(category);
                if (CategoryIds.Contains(category.Id))
                {
                    categoryVm.IsChecked = !categoryVm.IsChecked;
                }

                categoryViews.Add(categoryVm);
            }
            
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = productViews;
            productPageModel.Categories = categoryViews;
            productPageModel.searchWord = "";
            return View("Products", productPageModel);
        }
        
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            Product dto = _db.Products.Find(id);
            _db.Products.Remove(dto);
            _db.SaveChanges();
            // send successful message
            TempData["PSM"] = "You have deleted " + dto.Name + " product.";
            return RedirectToAction("Products");
        }
        
        [HttpGet]
        public IActionResult AddProduct()
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult AddProduct(ProductVM model)
        {
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string description;
            Product dto = new Product();
            dto.Name = model.Name.ToLower();
            if (string.IsNullOrWhiteSpace(model.Description))
            {
                description = model.Name.Replace(" ", "-");
            }
            else
            {
                description = model.Description;
            }

            if (_db.Products.Any(p => p.Name == model.Name.ToLower()))
            {
                ModelState.AddModelError("", "This name already exists.");
                return View(model);
            }

            dto.Description = description;
            dto.Price = model.Price;
            dto.Rate = model.Rate;
            dto.Image = model.Image;
            
            if (!_db.Categories.Where(c => c.Name.ToLower() == model.Category.Name.ToLower()).Any())
            {
                List<Category> categories = _db.Categories.ToList();
                string categoryNames = "";
                foreach (var category in categories)
                {
                    categoryNames += category.Name + ", ";
                }

                categoryNames = categoryNames.Substring(0, categoryNames.Length - 2);
                ModelState.AddModelError("", "This category does not exist. Categories available: " + categoryNames);
                return View(model);
            }
            
            Category newCategoryDto = _db.Categories.Where(c => c.Name.ToLower() == model.Category.Name.ToLower()).First();
            
            dto.UpdateByModel(model);
            dto.CategoryId = newCategoryDto.Id;

            _db.Products.Add(dto);
            _db.SaveChanges();
            // send successful message
            TempData["PSM"] = "You have added new product";
            return RedirectToAction("Products");
        }
    }
    
    
}