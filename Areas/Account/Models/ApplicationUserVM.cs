using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class ApplicationUserVM : ResetPasswordVM
    {
        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FName { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LName { get; set; }
    }
}