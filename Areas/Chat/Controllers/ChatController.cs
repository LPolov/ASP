using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Data;

namespace OnlineShop.Areas.Chat.Controllers
{
    [Area("Chat")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ChatController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET
        public IActionResult Index()
        {
            string email = HttpContext.User.Claims.Where(c => c.Type == "email").First().Value;
            ApplicationUser user = _db.ApplicationUsers.Where(u =>
                u.Email == email).First();
            return View(user);
        }
    }
}