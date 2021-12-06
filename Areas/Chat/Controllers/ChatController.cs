using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Areas.Chat.Controllers
{
    [Area("Chat")]
    public class ChatController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}