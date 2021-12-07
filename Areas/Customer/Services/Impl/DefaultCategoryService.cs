using System.Collections.Generic;
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
    }
}