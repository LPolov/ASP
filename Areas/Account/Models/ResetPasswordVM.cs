using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class ResetPasswordVM : LoginUserVM
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Password Confirmation")]
        public string PasswordConfirmation { get; set; }
    }
}