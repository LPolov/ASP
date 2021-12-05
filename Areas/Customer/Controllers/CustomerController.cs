using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}