using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Admin.Data
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public void UpdateByModel(ProductVM model)
        {
            if (Id != model.Id) {return;}
            
            Name = model.Name;
            Description = model.Description;
            Price = model.Price;
            Rate = model.Rate;
            Image = model.Image;
            CategoryId = model.Category.Id;
        }
    }
}