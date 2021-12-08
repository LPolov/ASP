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
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        
        [Range(0, 5)]
        public int Rate { get; set; }
        public CategoryVM Category { get; set; }
        
        [StringLength(50)]
        public string Image { get; set; }
    }
}