using System.Collections.Generic;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Customer.Services;

namespace OnlineShop.Areas.Customer.Mappers.Impl
{
    /*
     * Default implementation of IProductMapper.
     */
    public class DefaultProductMapper : IProductMapper
    {
        private ICategoryService _categoryService;
        
        public DefaultProductMapper(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /*
         * Maps each field of Product DAO from the list to each field of Product DTO.
         * Creates list of Product DTO from list of Product DAO.
         */
        public List<ProductVM> GetModels(IEnumerable<Product> products)
        {
            List<ProductVM> models = new List<ProductVM>();
            foreach (var product in products)
            {
                ProductVM productVm = new ProductVM(product);
                productVm.Category = new CategoryVM(_categoryService.GetCategoryById(product.CategoryId));
                models.Add(productVm);
            }
            return models;
        }

        /*
         * Maps each field of Product DAO to each field of Product DTO.
         */
        public ProductVM GetModel(Product product)
        {
            ProductVM model = new ProductVM(product);
            model.Category = new CategoryVM(_categoryService.GetCategoryById(product.CategoryId));
            return model;
        }
        
        /*
         * Maps single Product DTO to Product DAO.
         */
        public Product GetProductDao(ProductVM model)
        {
            Product product = new Product();
            product.Name = model.Name;
            var description = string.IsNullOrWhiteSpace(model.Description) ?
                model.Name.Replace(" ", "-") : 
                model.Description;
            product.Description = description;
            product.Price = model.Price;
            product.Rate = model.Rate;
            product.Image = model.Image;
            product.CategoryId = _categoryService.GetCategoryByName(model.Category.Name).Id;
            return product;
        }
    }
}