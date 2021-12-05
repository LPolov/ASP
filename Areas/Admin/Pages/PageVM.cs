using System.ComponentModel.DataAnnotations;
using OnlineShop.Areas.Admin.Models;

namespace OnlineShop.Areas.Admin.Pages
{
    public class PageVM
    {
        public PageVM()
        {
            
        }

        public PageVM(PageDto pageDto)
        {
            Id = pageDto.Id;
            Title = pageDto.Title;
            Slug = pageDto.Slug;
            Body = pageDto.Body;
            Sorting = pageDto.Sorting;
            HasSlider = pageDto.HasSlider;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Body { get; set; }
        public int Sorting { get; set; }
        
        [Display(Name = "Sidebar")]
        public bool HasSlider { get; set; }
    }
}