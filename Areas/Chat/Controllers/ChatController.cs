using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Data;

namespace OnlineShop.Areas.Chat.Controllers
{
    /*
     * Class to cover chat functionality.
     */
    [Area("Chat")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ChatController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        /*
         * Method takes logged in user and passes it to the view, which is used to display a chat.
         */
        [HttpGet]
        public IActionResult Index()
        {
            string email = HttpContext.User.Claims.First(c => c.Type == "email").Value;
            ApplicationUser user = _db.ApplicationUsers.First(u => u.Email == email);
            return View(user);
        }
    }
}