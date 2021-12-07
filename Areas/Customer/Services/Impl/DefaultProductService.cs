using System;
using System.Collections.Generic;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Customer.Data;
using OnlineShop.Areas.Customer.Mappers;

namespace OnlineShop.Areas.Customer.Services
{
    /*
     * Default implementation of IProductService.
     */
    public class DefaultProductService : IProductService
    {
        private ProductsRepository _repository;
        private IProductMapper _productMapper;
        private ICategoryService _categoryService;

        public DefaultProductService(ProductsRepository repository, IProductMapper productMapper, ICategoryService categoryService)
        {
            _repository = repository;
            _productMapper = productMapper;
            _categoryService = categoryService;
        }

        /*
         * Returns a List of all products from database mapped to DTO.
         */
        public List<ProductVM> GetProducts()
        {
            IEnumerable<Product> products = _repository.GetProducts();
            return _productMapper.GetModels(products);
        }

        /*
         * Returns a List of all products selected by a product name given by user from database and mapped to DTO.
         */
        public List<ProductVM> GetProductsByName(string name)
        {
            // If name is not given by user all products are returned.
            if (String.IsNullOrEmpty(name))
            {
                return GetProducts();
            }
            IEnumerable<Product> products = _repository.GetProductsByName(name);
            return _productMapper.GetModels(products);
        }

        /*
         * Returns a List of all products selected by a category given by user from database and mapped to DTO.
         */
        public List<ProductVM> GetProductsByCategoryId(int id)
        {
            /*
             * If user clicks on category which id is already in the set of categories ids, it means that he/she
             * disabled this category's button. Therefore this category is removed from categories set.
             */
            if (!CategoryVM.CategoriesId.Contains(id))
            {
                CategoryVM.CategoriesId.Add(id);
            }
            /*
             * Otherwise, selected category is added to the set.
             */
            else
            {
                CategoryVM.CategoriesId.Remove(id);
            }

            /*
             * If used disabled last category - all products are returned.
             */
            if (CategoryVM.CategoriesId.Count == 0)
            {
                return GetProducts();
            }

            IEnumerable<Product> products = _repository.GetProductsByCategoryId(id);
            return _productMapper.GetModels(products);
        }

        /*
         * Returns product DTO by specified product id.
         */
        public ProductVM GetProductById(int id)
        {
            Product product = _repository.GetProductById(id);
            return _productMapper.GetModel(product);
        }
        
        /*
         * Method updates product in database setting values given by user.
         */
        public void UpdateProductByModel(ProductVM model)
        {
            Product product = _repository.GetProductById(model.Id);
            CategoryVM category = _categoryService.GetCategoryByName(model.Category.Name.ToLower());

            if (product.Id == model.Id)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Rate = model.Rate;
                product.Image = model.Image;
                product.CategoryId = category.Id;
            }
            _repository.UpdateProduct(product);
        }
        
        /*
         * Method deletes product from database by passed product id.
         */
        public void DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
        }
        
        /*
         * Method adds new product to database.
         */
        public void AddProduct(ProductVM model)
        {
            _repository.AddProduct(_productMapper.GetProductDao(model));
        }
    }
}