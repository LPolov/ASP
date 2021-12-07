using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Customer.Services;

namespace OnlineShop.Areas.Customer.Controllers
{
    /*
     * Controller that is used to process data from user and display appropriate
     * pages related to products.
     */
    [Area("Customer")]
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
         * Method returns simple welcome page with static content.
         * Authorization is not required to get an access to this page.
         * If not authorized user or user with lack in authorities is trying to go to a restricted page
         * he/she is redirected to this page with error message displayed on it.
         */
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /*
         * Method returns a page with all products from database ordered by rate descending.
         * User can search products by name, or can select needed categories to get products belong to them.
         */
        [HttpGet]
        public IActionResult Products()
        {
            //Getting products and categories models to display on the page
            List<ProductVM> products = _productService.GetProducts();
            List<CategoryVM> categories = _categoryService.GetCategories();
            
            //Creating dynamic model to pass both Categories and Products to the page
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = products;
            productPageModel.Categories = categories;
            return View(productPageModel);
        }
        
        /*
         * Method allows to search products by name. It takes name from user and searches products
         * with names which contain it.
         */
        [HttpPost]
        public IActionResult Products(string name)
        {
            List<ProductVM> products = _productService.GetProductsByName(name);
            List<CategoryVM> categories = _categoryService.GetCategories();
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = products;
            productPageModel.Categories = categories;
            
            // If no product's name matches received word then error message is displayed on the page
            if (products.Count() == 0)
            {
                TempData["MNF"] = "Products not found.";
                return View(productPageModel);
            }
            return View("Products", productPageModel);
        }

        /*
         * Displays products by category
         */
        [HttpGet]
        public IActionResult ProductsByCategories(int categoryId)
        {
            List<ProductVM> products = _productService.GetProductsByCategoryId(categoryId);
            List<CategoryVM> categories = _categoryService.GetCategories();
            
            dynamic productPageModel = new ExpandoObject();
            productPageModel.Products = products;
            productPageModel.Categories = categories;
            return View("Products", productPageModel);
        }


        /*
         * Returns page with details of a chosen product.
         * To get this page user needs to be authorized.
         */
        [HttpGet]
        [Authorize]
        public IActionResult ProductDetails(int id)
        {
            return View(_productService.GetProductById(id));
        }
    }
}