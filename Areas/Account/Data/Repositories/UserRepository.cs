using System.Linq;
using OnlineShop.Areas.Account.Models;
using OnlineShop.Data;

namespace OnlineShop.Areas.Account.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _db;
        
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool IsAuthorizedUser(LoginUserVM user)
        {
            return _db.ApplicationUsers.Any(u => u.Email == user.Email.ToLower() && u.Password == user.Password);
        }
        
        public bool IsEmailAlreadyRegistered(ResetPasswordVM user)
        {
            return _db.ApplicationUsers.Any(u => u.Email == user.Email.ToLower());
        }
        
        public bool IsAdmin(LoginUserVM user)
        {
            return _db.ApplicationUsers.Where(u => u.IsAdmin).Any(u => u.Email == user.Email.ToLower());
        }
        
        public ApplicationUser Register(ApplicationUser user)
        {
            _db.ApplicationUsers.Add(user);
            _db.SaveChanges();
            return user;
        }
        
        public void ResetPassword(ApplicationUser user)
        {
            _db.ApplicationUsers.Update(user);
            _db.SaveChanges();
        }
        
        public ApplicationUser GetUserByEmail(string email)
        {
            return _db.ApplicationUsers.First(u => u.Email == email);
        }
    }
}