using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Admin.Services;
using OnlineShop.Areas.Customer.Mappers;
using OnlineShop.Areas.Customer.Services;

namespace OnlineShop.Areas.Admin.Controllers
{
    /*
     * CategoryController class is used to process admin requests.
     * Only user logged in as admin have an access to its methods.
     * It allows to do CRUD operations on categories.
     */
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private ICategoryMapper _categoryMapper;

        public CategoryController(ICategoryService categoryService, ICategoryMapper categoryMapper)
        {
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
        }
        
        /*
         * Returns a view with all categories stored in database.
         */
        [HttpGet]
        public IActionResult Categories()
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
            return View(_categoryService.GetCategories());
        }
        
        /*
         * Returns page to edit selected category.
         */
        [HttpGet]
        public IActionResult EditCategory(int id)
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
            Category category = _categoryService.GetCategoryById(id);
            
            /*
             * If no category found error message is displayed.
             */
            if (category == null)
            {
                return Content("This page does not exist.");
            }
            return View(_categoryMapper.GetModel(category));
        }
        
        /*
         * Gets data from user and updates category according to this data.
         */
        [HttpPost]
        public IActionResult EditCategory(CategoryVM model)
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
             * Category model's fields are incorrect it displays error message.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            Category updatedCategory = _categoryService.UpdateCategory(model);
            
            /*
             * If updatedCategory it means that category with specified name already exists.
             * Then appropriate message is displayed.
             */
            if (updatedCategory == null)
            {
                ModelState.AddModelError("", "This name already exists.");
                return View(model);
            }
            
            // Send successful message.
            TempData["CSM"] = "You have updated " + updatedCategory.Name + " category.";
            return RedirectToAction("Categories");
        }
        
        /*
         * Deletes category from db.
         */
        [HttpGet]
        public IActionResult DeleteCategory(int id)
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
            
            _categoryService.DeleteCategory(id);
            // Send successful message
            TempData["CSM"] = "You have deleted product.";
            return RedirectToAction("Categories");
        }
        
        /*
         * Returns page to add new category.
         */
        [HttpGet]
        public IActionResult AddCategory()
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
         * Gets data from user and creates new category based on it.
         */
        [HttpPost]
        public IActionResult AddCategory(CategoryVM model)
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
             * Category model's fields are incorrect it displays error message.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Category category = _categoryService.AddCategory(model);
            
            /*
             * If updatedCategory it means that category with specified name already exists.
             * Then appropriate message is displayed.
             */
            if (category == null)
            {
                ModelState.AddModelError("", "This name already exists.");
                return View(model);
            }
            
            // Send successful message
            TempData["CSM"] = "You have added new category";
            return RedirectToAction("Categories");
        }
    }
}
