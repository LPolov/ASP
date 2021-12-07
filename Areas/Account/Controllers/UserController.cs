using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;
using OnlineShop.Data;

namespace OnlineShop.Areas.Account.Controllers
{
    [Area("Account")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        // GET
        [HttpGet(Name = "login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            if (!_db.ApplicationUsers.Any(u => u.Email == model.Email.ToLower())) 
            {
                ModelState.AddModelError("", "This email not found");
                return View(model);
            }
            
            if (!_db.ApplicationUsers.Any(u => u.Password == model.Password)) 
            {
                ModelState.AddModelError("", "Password is incorrect");
                return View(model);
            }
            if (_db.ApplicationUsers.Where(u => u.IsAdmin).Any(u => u.Email == model.Email.ToLower()))
            {
                ClaimsIdentity claimIdentity = new ClaimsIdentity(new List<Claim>() {new Claim("userType", "admin"), new Claim("email", model.Email)}, "Cookies");
                ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookies", claimPrincipal);
                return RedirectToAction("Products", "Product", new { area = "admin" });
            }
            ClaimsIdentity claimUserIdentity = new ClaimsIdentity(new List<Claim>() {new Claim("userType", "customer"), new Claim("email", model.Email)}, "Cookies");
            ClaimsPrincipal claimUserPrincipal = new ClaimsPrincipal(claimUserIdentity);
            await HttpContext.SignInAsync("Cookies", claimUserPrincipal);
            return RedirectToAction("Index", "Product", new { area = "Customer" });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            if (_db.ApplicationUsers.Any(u => u.Email == model.Email.ToLower())) 
            {
                ModelState.AddModelError("", "This email is already registered.");
                return View(model);
            }
            
            if (model.Password != model.ConfirmPassword) 
            {
                ModelState.AddModelError("", "Password and password confirmation are not equal.");
                return View(model);
            }

            ApplicationUser dto = new ApplicationUser();
            dto.FName = model.FName;
            dto.LName = model.LName;
            dto.Email = model.Email;
            dto.Password = model.Password;
            _db.ApplicationUsers.Add(dto);
            _db.SaveChanges();
            
            ClaimsIdentity claimIdentity = new ClaimsIdentity(new List<Claim>() {new Claim("userType", "customer"), new Claim("email", model.Email)}, "Cookies");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookies", claimPrincipal);
            return RedirectToAction("Index", "Product", new { area = "customer" });
        }
        
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            if (!_db.ApplicationUsers.Any(u => u.Email == model.Email.ToLower())) 
            {
                ModelState.AddModelError("", "This email is not registered.");
                return View(model);
            }
            
            if (model.Password != model.PasswordConfirmation) 
            {
                ModelState.AddModelError("", "Password and password confirmation are not equal.");
                return View(model);
            }

            ApplicationUser dto = _db.ApplicationUsers.Where(u => u.Email == model.Email).First();
            dto.Password = model.Password;
            _db.ApplicationUsers.Update(dto);
            _db.SaveChanges();
            return RedirectToAction("Index", "Product", new { area = "customer" });
        }
    }
}