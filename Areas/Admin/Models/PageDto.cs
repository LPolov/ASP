using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Areas.Admin.Pages;

namespace OnlineShop.Areas.Admin.Models
{
    [Table("pages")]
    public class PageDto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public int Sorting { get; set; }
        public bool HasSlider { get; set; }
        
        public void UpdateByModel(PageVM model)
        {
            if (Id != model.Id) {return;}
            
            string modelSlug = "home";
            if (string.IsNullOrWhiteSpace(model.Slug))
            {
                modelSlug = model.Title.Replace(" ", "-").ToLower();
            }
            else if (model.Slug != "home")
            {
                modelSlug = model.Slug.Replace(" ", "-").ToLower();
            }
            Title = model.Title;
            Slug = modelSlug;
            Body = model.Body;
            HasSlider = model.HasSlider;
        }
    }
}