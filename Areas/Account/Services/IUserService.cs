using System.Security.Claims;
using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;

namespace OnlineShop.Areas.Account.Services
{
    /*
     * Interface gives methods to work with users.
     */
    public interface IUserService
    {
        /*
         * Returns true if passed user is registered and password matches to password in db.
         */
        public bool IsAuthorizedUser(LoginUserVM user);
        
        /*
         * Returns true if passed user is admin.
         */
        public bool IsAdmin(LoginUserVM user);
        
        /*
         * Returns ClaimsPrincipal for given user by his/her type.
         */
        public ClaimsPrincipal GetPrincipal(LoginUserVM user, string userType);
        
        /*
         * Register passed user and returns her/his ClaimsPrincipal.
         */
        public ClaimsPrincipal RegisterUser(ResetPasswordVM user);
        
        /*
         * Resets password for passed user.
         */
        public ApplicationUser ResetPassword(ResetPasswordVM user);
    }
}