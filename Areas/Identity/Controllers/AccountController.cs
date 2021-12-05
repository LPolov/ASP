using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        // GET
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
    }
}