using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class ResetPasswordVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}