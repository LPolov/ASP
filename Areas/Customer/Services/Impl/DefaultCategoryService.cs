using System.Collections.Generic;
using System.Linq;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Customer.Data;
using OnlineShop.Areas.Customer.Mappers;

namespace OnlineShop.Areas.Customer.Services
{
    /*
     * Default implementation of ICustomerService.
     */
    public class DefaultCategoryService : ICategoryService
    {
        private readonly CategoryRepository _repository;
        private readonly ICategoryMapper _categoryMapper;

        public DefaultCategoryService(CategoryRepository repository, ICategoryMapper categoryMapper)
        {
            _repository = repository;
            _categoryMapper = categoryMapper;
        }
        
        /*
         * Get all categories from repository and maps them to DTO.
         */
        public List<CategoryVM> GetCategories()
        {
            IEnumerable<Category> categories = _repository.GetCategories();
            return _categoryMapper.GetModels(categories);
        }
        
        /*
         * Get category specified by id from repository and maps it to DTO.
         */
        public Category GetCategoryById(int id)
        {
            return _repository.GetCategoryById(id);
        }
        
        /*
        * Method returns true if category with passed name exists, and returns false if not.
        */
        public bool DoesCategoryNameExist(string name)
        {
            return _repository.DoesCategoryNameExist(name);
        }
        
        /*
        * Method returns all categories names separated by comma.
        */
        public string GetCategoriesNamesAsString()
        {
           IEnumerable<string> names = _repository.GetCategoriesNames();
           // Concatenate each word to the result string
           string result = names.Aggregate("", (current, name) => current + (name + ", "));
           // Removes list space and comma
           return result[..^2];
        }
        
        /*
        * Method returns a category which name matches passed name.
        */
        public CategoryVM GetCategoryByName(string name)
        {
            Category category = _repository.GetCategoryByName(name);
            return _categoryMapper.GetModel(category);
        }
        
        /*
        * Method updates a category specified by id.
        */
        public Category UpdateCategory(CategoryVM model)
        {
            Category category = _repository.GetCategoryById(model.Id);
            
            if (model.Name != category.Name && _repository.DoesCategoryNameExist(model.Name))
            {
                return null;
            }
            category.Name = model.Name;
            category.Description = model.Description;
            _repository.UpdateCategory(category);
            return category;
        }
        
        /*
         * Method deletes a category specified by id.
         */
        public void DeleteCategory(int id)
        {
            _repository.DeleteCategory(GetCategoryById(id));
        }
        
        /*
         * Method adds new category.
         */
        public Category AddCategory(CategoryVM model)
        {
            if (_repository.DoesCategoryNameExist(model.Name))
            {
                return null;
            }
            Category category = _categoryMapper.GetCategoryDao(model);
            _repository.AddCategory(category);
            return category;
        }
    }
}