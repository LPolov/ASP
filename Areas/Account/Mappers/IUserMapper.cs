using OnlineShop.Areas.Account.Data;
using OnlineShop.Areas.Account.Models;

namespace OnlineShop.Areas.Account.Mappers
{
    /*
     * Interface is used to map User DTO to User DAO.
     */
    public interface IUserMapper
    {
        /*
         * Maps single User DTO to User DAO.
         */
        public ApplicationUser GetProductDao(ResetPasswordVM model);
    }
}