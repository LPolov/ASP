using System.Linq;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Areas.Admin.Services
{
    public class AdminService
    {
        public static bool IsCurrentUserAdmin(HttpContext ctx)
        {
            return ctx.User.Claims.First(c => c.Type == "userType").Value == "admin";
        }
    }
}