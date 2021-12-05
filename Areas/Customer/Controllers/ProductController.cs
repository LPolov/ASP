using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Account.Models;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Data;

namespace OnlineShop.Areas.Customer.Controllers
{
    [Area("Customer")]
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
            IEnumerable<Product> products = _db.Products.OrderBy(p => p.Rate).ToList();
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
            return View(productPageModel);
        }
        
        [HttpPost]
        public IActionResult Products(string searchWord)
        {
            if (String.IsNullOrEmpty(searchWord))
            {
                return RedirectToAction("Products");
            }

            IEnumerable<Product> products = _db.Products
                .Where(p => p.Name.ToLower().Contains(searchWord.ToLower()) && (CategoryIds.Contains(p.CategoryId) || CategoryIds.Count() == 0))
                .OrderBy(p => p.Rate)
                .ToList();

            List<ProductVM> productViews = new List<ProductVM>();
            if (products.Count() == 0)
            {
                ModelState.AddModelError("", "Product not found.");
                return View(productViews);
            }
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
            return View("Products", productPageModel);
        }
        
        [HttpPost]
        protected void Products(object sender, EventArgs e)
        {

        
        }

        [HttpGet]
        public IActionResult ProductsByCategories(int categoryId)
        {
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
            return View("Products", productPageModel);
        }


        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            Product product = _db.Products.Find(id);
            ProductVM productVm = new ProductVM(product);
            productVm.Category = new CategoryVM(_db.Categories.Find(product.CategoryId));
            return View(productVm);
        }
    }
}