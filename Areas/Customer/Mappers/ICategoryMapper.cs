using System.Collections.Generic;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Customer.Mappers
{
    /*
     * Mapper Interface to map Category DAO to Category DTO.
     */
    public interface ICategoryMapper
    {
        /*
         * Maps list of Category DAO to list of Category DTO.
         */
        public List<CategoryVM> GetModels(IEnumerable<Category> category);
        
        /*
        * Maps Category DAO Category DTO.
        */
        public CategoryVM GetModel(Category category);
        
        /*
        * Maps Category DTO Category DAO.
        */
        public Category GetCategoryDao(CategoryVM model);
    }
}