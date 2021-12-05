using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class ApplicationUserVM
    {
        public string FName { get; set; }
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}