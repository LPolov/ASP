using System.Security.Claims;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;

namespace OnlineShop.Areas.Account.Services
{
    public interface IUserService
    {
        public bool IsAuthorizedUser(LoginUserVM user);
        public bool IsAdmin(LoginUserVM user);
        public ClaimsPrincipal GetPrincipal(LoginUserVM user, string userType);
        public ClaimsPrincipal RegisterUser(ResetPasswordVM user);
        public ApplicationUser ResetPassword(ResetPasswordVM user);
    }
}