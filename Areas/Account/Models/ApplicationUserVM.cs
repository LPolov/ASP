using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Account.Models
{
    public class ApplicationUserVM : ResetPasswordVM
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
}