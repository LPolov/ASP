using System.Collections.Generic;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Customer.Mappers
{
    /*
     * Mapper Interface to map Product DAO to Product DTO.
     */
    public interface IProductMapper
    {
        /*
         * Maps list of Product DAO to list of Product DTO.
         */
        public List<ProductVM> GetModels(IEnumerable<Product> products);
        
        /*
         * Maps single Product DAO to Product DTO.
         */
        public ProductVM GetModel(Product product);
        
        /*
         * Maps single Product DTO to Product DAO.
         */
        public Product GetProductDao(ProductVM model);
    }
}