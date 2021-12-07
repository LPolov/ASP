using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class ResetPasswordVM : LoginUserVM
    {
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}