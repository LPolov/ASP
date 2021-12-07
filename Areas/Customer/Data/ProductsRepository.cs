using System.Collections.Generic;
using System.Linq;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Data;

namespace OnlineShop.Areas.Customer.Data
{
    /*
     * DAO Layer that is used to get Product objects from database.
     */
    public class ProductsRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /*
        * Returns all products stored in database.
        */
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.OrderBy(p => p.Rate).ToList();
        }
        
        /*
        * Returns product from database which has specified id.
        */
        public Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }
        
        /*
        * Returns product from database which name contains passed parameter called "name".
        * Method also takes into account categories selected by user and if product with appropriate name
        * is found but it is in category not selected by user - product will not be returned.
        */
        public IEnumerable<Product> GetProductsByName(string name)
        {
            return _db.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()) 
                            && (CategoryVM.CategoriesId.Contains(p.CategoryId) || CategoryVM.CategoriesId.Count() == 0))
                .OrderBy(p => p.Rate)
                .ToList();;
        }
        
        /*
        * Returns all products from category selected by a user.
        */
        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            return _db.Products.Where(p => CategoryVM.CategoriesId.Contains(p.CategoryId)).
                OrderBy(p => p.Rate)
                .ToList();
        }
    }
}