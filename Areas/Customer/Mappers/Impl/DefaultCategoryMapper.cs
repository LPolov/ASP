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
                CategoryVM categoryVm = new CategoryVM(category);
                if (CategoryVM.CategoriesId.Contains(category.Id))
                {
                    categoryVm.IsChecked = true;
                }
                models.Add(categoryVm);
            }

            return models;
        }
    }
}