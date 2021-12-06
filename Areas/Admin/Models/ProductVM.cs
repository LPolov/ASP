using System.ComponentModel.DataAnnotations;
using OnlineShop.Areas.Admin.Data;

namespace OnlineShop.Areas.Admin.Models
{
    public class ProductVM
    {
        public ProductVM()
        {
        }
        
        public ProductVM(Product dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            Price = dto.Price;
            Rate = dto.Rate;
            Image = dto.Image;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public int Rate { get; set; }
        public CategoryVM Category { get; set; }
        public string Image { get; set; }
    }
}