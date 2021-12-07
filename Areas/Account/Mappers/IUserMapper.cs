using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;

namespace OnlineShop.Areas.Account.Mappers
{
    public interface IUserMapper
    {
        /*
         * Maps single Product DTO to Product DAO.
         */
        public ApplicationUser GetProductDao(ResetPasswordVM model);
    }
}