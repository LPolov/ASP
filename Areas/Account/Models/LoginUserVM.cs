using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class LoginUserVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}