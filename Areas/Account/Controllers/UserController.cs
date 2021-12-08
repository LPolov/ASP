using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;
using OnlineShop.Areas.Account.Services;

namespace OnlineShop.Areas.Account.Controllers
{
    /*
     * This controller is used for login, registration and logout.
     */
    [Area("Account")]
    public class UserController : Controller
    {
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        /*
         * Returns a view to login.
         */
        [HttpGet(Name = "login")]
        public IActionResult Login()
        {
            return View();
        }
        
        /*
         * Process user request to login.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            /*
             * If user model's fields store incorrect data error message will be displayed.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            /*
             * If email is not found or password does not match with record in db error message is displayed.
             */
            if (!_userService.IsAuthorizedUser(model)) 
            {
                ModelState.AddModelError("", "Email or password is invalid");
                return View(model);
            }
            
            /*
             * If user is and admin he/she will be signed in with admin usertype, otherwise with customer usertype.
             */
            if (_userService.IsAdmin(model))
            {
                await HttpContext.SignInAsync("Cookies", _userService.GetPrincipal(model, "admin"));
                return RedirectToAction("Products", "Product", new { area = "admin" });
            }
            await HttpContext.SignInAsync("Cookies",  _userService.GetPrincipal(model, "customer"));
            return RedirectToAction("Index", "Product", new { area = "Customer" });
        }

        /*
         * When user logout all cookies are removed.
         */
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }
        
        /*
         * Returns view for registrations.
         */
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        /*
         * Method takes registration model and check whether its fields are valid. If every field is valid
         * user will be registered, otherwise error message will be displayed.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserVM model)
        {
            /*
             * If user model's fields store incorrect data error message will be displayed.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            ClaimsPrincipal claimPrincipal = _userService.RegisterUser(model);
            
            /*
             * If password and password confirmation does not match or email is already registered error message
             * will be displayed.
             */
            if (claimPrincipal == null)
            {
                ModelState.AddModelError("", "Either email is already registered or password confirmation" +
                                             " mismatches password. Check entered data.");
                return View(model);
            }
            await HttpContext.SignInAsync("Cookies", claimPrincipal);
            return RedirectToAction("Index", "Product", new { area = "customer" });
        }
        
        /*
         * Returns a view for password reset.
         */
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        
        /*
         * Method checks whether passed model is valid. If it is - password is reset, otherwise - not.
         */
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordVM model)
        {
            /*
             * If user model's fields store incorrect data error message will be displayed.
             */
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser dto = _userService.ResetPassword(model);
            
            /*
             * Application user DTO is equal to null when email is not registered or password and password confirmation
             * does not match.
             */
            if (dto != null)
            {
                return RedirectToAction("Index", "Product", new {area = "customer"});
            }
            ModelState.AddModelError("", "Either email is already registered or password confirmation" +
                                         " mismatches password. Check entered data.");
            return View(model);
        }
    }
}