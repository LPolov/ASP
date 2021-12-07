using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Admin.Services;
using OnlineShop.Areas.Customer.Services;

namespace OnlineShop.Areas.Admin.Controllers
{
    /*
     * ProductController class is used to process admin requests.
     * Only user logged in as admin have an access to its methods.
     * It allows to do CRUD operations on products.
     */
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        
        /*
         * Returns view with all products from database.
         */
        [HttpGet]
        public IActionResult Products()
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            List<ProductVM> products = _productService.GetProducts();
            List<CategoryVM> categories = _categoryService.GetCategories();
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = products;
            productPageModel.Categories = categories;
            return View(productPageModel);
        }
        
        /*
         * Returns a page where admin can modify selected product
        */
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            ProductVM product = _productService.GetProductById(id);
            
            // If no product found error message is displayed.
            if (product == null)
            {
                return Content("This page does not exist.");
            }
            
            return View(product);
        }
        
        /*
         * Process request from admin to update product and updates it in database.
         */
        [HttpPost]
        public IActionResult EditProduct(ProductVM model)
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "You are not allowed to send post requests here.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            /*
             * If model's fields are filled with incorrect data error message will be displayed in
             * Validation Summary area.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            /*
             * If admin enters category name which does not exist in database - error message is displayed
             * in Validation Summary area.
             */
            if (!_categoryService.DoesCategoryNameExist(model.Category.Name))
            {
                string allowedNames = _categoryService.GetCategoriesNamesAsString();
                ModelState.AddModelError("", "This category does not exist. Categories available: " + allowedNames);
                return View(model);
            }
            
            _productService.UpdateProductByModel(model);
            
            // Send successful message when model successfully updated
            TempData["PSM"] = "You have updated " + model.Name + " product.";
            return RedirectToAction("Products");
        }
        
        /*
         * Method allows to search products by name. It takes name from user and searches products
         * with names which contain it.
         */
        [HttpPost]
        public IActionResult Products(string name)
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "You are not allowed to send post requests here.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }

            List<ProductVM> products = _productService.GetProductsByName(name);
            IEnumerable<CategoryVM> categories = _categoryService.GetCategories();
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = products;
            productPageModel.Categories = categories;
            
            if (products.Any())
            {
                return View("Products", productPageModel);
            }
            
            // If no product's name matches received word then error message is displayed on the page
            ModelState.AddModelError("", "Product not found.");
            return View(productPageModel);
        }
        
        /*
         * Displays products by category
         */
        [HttpGet]
        public IActionResult ProductsByCategories(int categoryId)
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            List<ProductVM> products = _productService.GetProductsByCategoryId(categoryId);
            List<CategoryVM> categories = _categoryService.GetCategories();
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = products;
            productPageModel.Categories = categories;
            
            return View("Products", productPageModel);
        }
        
        /*
         * Deletes product from db by passed product id.
         */
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            _productService.DeleteProduct(id);
            
            // Send successful message when product is successfully deleted.
            TempData["PSM"] = "You have deleted product.";
            return RedirectToAction("Products");
        }
        
        /*
         * Returns page to add new product.
         */
        [HttpGet]
        public IActionResult AddProduct()
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            return View();
        }
        
        /*
         * Takes all data from admin and creates new product in database based on this data.
         */
        [HttpPost]
        public IActionResult AddProduct(ProductVM model)
        {
            /*
             * If user is not authorized as admin Connection Refused error message is displayed
             * on Products page
             */
            if (!AdminService.IsCurrentUserAdmin(HttpContext))
            {
                TempData["CR"] = "Login as admin to have an access to this page.";
                return RedirectToAction("Index", "Product", new {Area = "Customer"});
            }
            
            /*
             * If model's fields are filled with incorrect data error message will be displayed in
             * Validation Summary area.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            /*
             * If admin enters category name which does not exist in database - error message is displayed
             * in Validation Summary area.
             */
            if (!_categoryService.DoesCategoryNameExist(model.Category.Name))
            {
                string allowedNames = _categoryService.GetCategoriesNamesAsString();
                ModelState.AddModelError("", "This category does not exist. Categories available: " + allowedNames);
                return View(model);
            }
            
            _productService.AddProduct(model);
            
            // Send successful message when new product is successfully added.
            TempData["PSM"] = "You have added new product";
            return RedirectToAction("Products");
        }
    }
}
