using System.Collections.Generic;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Customer.Services
{
    /*
     * Interface for Product Services. Contains methods to work with products.
     */
    public interface IProductService
    {
        
        /*
         * Gets all products from product repository.
         */
        public List<ProductVM> GetProducts();
        
        /*
         * Gets list if product from product repository by specified product name.
         */
        public List<ProductVM> GetProductsByName(string name);
        
        /*
         * Gets list of products from product repository that belongs to specified category
         * selected by user and which id is passed as a parameter.
         */
        public List<ProductVM> GetProductsByCategoryId(int id);
        
        /*
         * Gets product from repository by id.
         */
        public ProductVM GetProductById(int id);

        /*
         * Method updates product in database setting values given by user.
         */
        public void UpdateProductByModel(ProductVM model);
        
        /*
         * Method deletes product from database by passed product id.
         */
        public void DeleteProduct(int id);
        
        /*
         * Method adds new product to database.
         */
        public void AddProduct(ProductVM model);
    }
}