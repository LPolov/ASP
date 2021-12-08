using System.Linq;
using OnlineShop.Areas.Account.Models;
using OnlineShop.Data;

namespace OnlineShop.Areas.Account.Data.Repositories
{
    /*
     * This repository is used to get an access to a table with users.
     */
    public class UserRepository
    {
        private readonly ApplicationDbContext _db;
        
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /*
         * Returns true if email is registered and password matches.
         */
        public bool IsAuthorizedUser(LoginUserVM user)
        {
            return _db.ApplicationUsers.Any(u => u.Email == user.Email.ToLower() && u.Password == user.Password);
        }
        
        /*
         * Returns true if email is registered.
         */
        public bool IsEmailAlreadyRegistered(ResetPasswordVM user)
        {
            return _db.ApplicationUsers.Any(u => u.Email == user.Email.ToLower());
        }
        
        /*
         * Returns true if passed user is admin.
         */
        public bool IsAdmin(LoginUserVM user)
        {
            return _db.ApplicationUsers.Where(u => u.IsAdmin).Any(u => u.Email == user.Email.ToLower());
        }
        
        /*
         * Register new user.
         */
        public ApplicationUser Register(ApplicationUser user)
        {
            _db.ApplicationUsers.Add(user);
            _db.SaveChanges();
            return user;
        }
        
        /*
         * Reset password of already registered user.
         */
        public void ResetPassword(ApplicationUser user)
        {
            _db.ApplicationUsers.Update(user);
            _db.SaveChanges();
        }
        
        /*
         * Returns user DAO by given email.
         */
        public ApplicationUser GetUserByEmail(string email)
        {
            return _db.ApplicationUsers.First(u => u.Email == email);
        }
    }
}