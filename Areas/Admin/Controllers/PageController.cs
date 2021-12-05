using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Admin.Pages;
using OnlineShop.Data;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public PageController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET
        public IActionResult Index()
        { 
            IEnumerable<PageDto> pageList = _db.Pages.OrderBy(p => p.Sorting).ToList();
            List<PageVM> pages = new List<PageVM>();
            foreach (var page in pageList)
            {
                pages.Add(new PageVM(page));
            }
            return View(pages);
        }
        
        // GET Admin/Page/AddPage
        [HttpGet]
        public IActionResult AddPage()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddPage(PageVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string slug;
            PageDto pageDto = new PageDto();
            pageDto.Title = model.Title.ToUpper();
            if (string.IsNullOrWhiteSpace(model.Slug))
            {
                slug = model.Title.Replace(" ", "-").ToLower();
            }
            else
            {
                slug = model.Slug.Replace(" ", "-").ToLower();
            }

            if (_db.Pages.Any(p => p.Title == model.Title.ToUpper()))
            {
                ModelState.AddModelError("", "This title already exists.");
                return View(model);
            }

            pageDto.Slug = slug;
            pageDto.Body = model.Body;
            pageDto.HasSlider = model.HasSlider;
            //to put row to the bottom of table
            pageDto.Sorting = 100;

            _db.Pages.Add(pageDto);
            _db.SaveChanges();
            // send successful message
            TempData["SM"] = "You have added new page";
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult EditPage(int id)
        {
            PageVM model;
            PageDto dto = _db.Pages.Find(id);
            if (dto == null)
            {
                return Content("This page does not exist.");
            }

            model = new PageVM(dto);
            return View(model);
        }
        
        [HttpPost]
        public IActionResult EditPage(PageVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            PageDto dto = _db.Pages.Find(model.Id);
            
            if (model.Title != dto.Title && _db.Pages.Any(p => p.Title == model.Title.ToUpper()))
            {
                ModelState.AddModelError("", "This title already exists.");
                return View(model);
            }
            dto.UpdateByModel(model);
            _db.SaveChanges();
            // send successful message
            TempData["SM"] = "You have updated " + dto.Title + " page.";
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult DeletePage(int id)
        {
            PageDto dto = _db.Pages.Find(id);
            _db.Pages.Remove(dto);
            _db.SaveChanges();
            // send successful message
            TempData["SM"] = "You have deleted " + dto.Title + " page.";
            return RedirectToAction("Index");
        }
    }
}