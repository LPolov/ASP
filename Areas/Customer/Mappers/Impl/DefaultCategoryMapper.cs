using System.Collections.Generic;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Customer.Mappers.Impl
{
    /*
     * Default implementation of ICategoryMapper.
     */
    public class DefaultCategoryMapper : ICategoryMapper
    {
        /*
         * Maps each field of Category DAO from the list to each field of Category DTO.
         * Creates list of Category DTO from list of Category DAO.
         */
        public List<CategoryVM> GetModels(IEnumerable<Category> categories)
        {
            List<CategoryVM> models = new List<CategoryVM>();
            foreach (var category in categories)
            {
                CategoryVM categoryVm = GetModel(category);
                models.Add(categoryVm);
            }
            return models;
        }
        
        /*
        * Maps Category DAO Category DTO.
        */
        public CategoryVM GetModel(Category category)
        {
            CategoryVM model = new CategoryVM(category);
            if (CategoryVM.CategoriesId.Contains(category.Id))
            {
                model.IsChecked = true;
            }
            return model;
        }
        
        /*
        * Maps Category DTO Category DAO.
        */
        public Category GetCategoryDao(CategoryVM model)
        {
            Category category = new Category();
            category.Name = model.Name.ToLower();
            category.Description = string.IsNullOrWhiteSpace(model.Description) ? 
                model.Name.Replace(" ", "-").ToLower() : 
                model.Description;
            return category;
        }
    }
}