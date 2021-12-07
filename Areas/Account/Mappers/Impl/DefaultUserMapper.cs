using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;

namespace OnlineShop.Areas.Account.Mappers.Impl
{
    public class DefaultUserMapper : IUserMapper
    {
        public ApplicationUser GetProductDao(ResetPasswordVM model)
        {
            ApplicationUser user = new ApplicationUser();
            user.FName = ((ApplicationUserVM) model).FName;
            user.LName = ((ApplicationUserVM) model).LName;
            user.Email = model.Email;
            user.Password = model.Password;
            return user;
        }
    }
}