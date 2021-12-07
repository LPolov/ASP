using System.Collections.Generic;
using System.Linq;
using OnlineShop.Areas.Admin.Data;
using OnlineShop.Data;

namespace OnlineShop.Areas.Customer.Data
{
    /*
     * DAO Layer that is used to get Category objects from database.
     */
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        /*
        * Returns all categories stored in database.
        */
        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        
        /*
        * Returns category from database which has specified id.
        */
        public Category GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }
    }
}