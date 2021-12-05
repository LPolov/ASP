using System.Xml.XPath;
using OnlineShop.Areas.Admin.Data;

namespace OnlineShop.Areas.Admin.Models
{
    public class CategoryVM
    {
        public CategoryVM()
        {
        }

        public CategoryVM(Category dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                CategoryVM c = (CategoryVM) obj;
                return (c.Id == Id) && (c.Name == Name) && (c.Description == Description);
            }
        }
    }
}