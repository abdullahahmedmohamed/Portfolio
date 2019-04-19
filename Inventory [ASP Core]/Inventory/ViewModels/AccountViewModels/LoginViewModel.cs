using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
