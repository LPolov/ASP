using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class LoginUserVM
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}