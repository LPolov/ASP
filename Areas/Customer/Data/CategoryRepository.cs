using System;
using System.Collections.Generic;
using System.Data;
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
        
        /*
        * Method returns true if category with passed name exists, and returns false if not.
        */
        public bool DoesCategoryNameExist(string name)
        {
            return _db.Categories.Any(c => string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
        
        /*
        * Method returns all categories names.
        */
        public IEnumerable<string> GetCategoriesNames()
        {
            return _db.Categories.Select(c => c.Name);
        }
        
        /*
        * Method returns a category which name matches passed name.
        */
        public Category GetCategoryByName(string name)
        {
            return _db.Categories.First(c => string.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
        
        /*
        * Method updates a category.
        */
        public void UpdateCategory(Category category)
        {
            _db.Update(category);
            _db.SaveChanges();
        }
        
        /*
        * Method deletes category form db.
        */
        public void DeleteCategory(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
        
        /*
        * Method returns adds new category to db.
        */
        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }
    }
}