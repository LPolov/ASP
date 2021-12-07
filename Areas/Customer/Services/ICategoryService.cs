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
        public Category GetCategoryById(int id);

        /*
         * Method returns true if category with passed name exists, and returns false if not.
         */
        public bool DoesCategoryNameExist(string name);
        
        /*
         * Method returns all categories names as in one string.
         */
        public string GetCategoriesNamesAsString();
        
        /*
         * Method returns a category which name matches passed name.
         */
        public CategoryVM GetCategoryByName(string name);
        
        /*
         * Method updates a category specified by id.
         */
        public Category UpdateCategory(CategoryVM model);
        
        /*
         * Method deletes a category specified by id.
         */
        public void DeleteCategory(int id);
        
        /*
         * Method adds new category.
         */
        public Category AddCategory(CategoryVM model);
    }
}