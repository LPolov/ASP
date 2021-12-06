using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Data;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        // GET
        [HttpGet]
        public IActionResult Categories()
        {
            List<Category> categories = _db.Categories.ToList();
            List<CategoryVM> categoryViews = new List<CategoryVM>();
            foreach (var category in categories)
            {
                categoryViews.Add(new CategoryVM(category));
            }
            return View(categoryViews);
        }
        
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            CategoryVM model;
            Category dto = _db.Categories.Find(id);
            if (dto == null)
            {
                return Content("This page does not exist.");
            }

            model = new CategoryVM(dto);
            return View(model);
        }
        
        [HttpPost]
        public IActionResult EditCategory(CategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Category dto = _db.Categories.Find(model.Id);
            
            if (model.Name != dto.Name && _db.Categories.Any(p => p.Name.ToLower() == model.Name.ToLower()))
            {
                ModelState.AddModelError("", "This name already exists.");
                return View(model);
            }
            dto.UpdateByModel(model);
            _db.Update(dto);
            _db.SaveChanges();
            // send successful message
            TempData["CSM"] = "You have updated " + dto.Name + " category.";
            return RedirectToAction("Categories");
        }
        
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Category dto = _db.Categories.Find(id);
            _db.Categories.Remove(dto);
            _db.SaveChanges();
            // send successful message
            TempData["CSM"] = "You have deleted " + dto.Name + " page.";
            return RedirectToAction("Categories");
        }
        
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddCategory(CategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            Category dto = new Category();
            dto.Name = model.Name.ToLower();
            string description = null;
            if (string.IsNullOrWhiteSpace(model.Description))
            {
                description = model.Name.Replace(" ", "-").ToLower();
            }
            else
            {
                description = model.Description;
            }

            dto.Description = description;
            if (_db.Categories.Any(c => c.Name == model.Name.ToLower()))
            {
                ModelState.AddModelError("", "This name already exists.");
                return View(model);
            }
            

            _db.Categories.Add(dto);
            _db.SaveChanges();
            // send successful message
            TempData["CSM"] = "You have added new category";
            return RedirectToAction("Categories");
        }
    }
}