using System.Collections.Generic;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Customer.Services
{
    /*
     * Interface for Category Services. Contains methods to work with categories.
     */
    public interface ICategoryService
    {
        /*
         * Method is used to get all categories from repository.
         */
        public List<CategoryVM> GetCategories();
        
        /*
         * Method is used to get category from repository by id.
         */
        public Category GetCategoryById(int Id);
    }
}