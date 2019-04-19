using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [StringLength(60)]
        [Required]
        [Display(Name = "Full Name")]
        public string fullName { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "ID Number")]
        public string idNo { get; set; }

        
        [Display(Name = "Picture")]
        public IFormFile pic { get; set; }

        [Required]
        [Display(Name = "Join Date")]
        public DateTime joinDate { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime birthDate { get; set; }

        [Required]
        [Display(Name = "Role")]
        public long RoleId { get; set; }
        
    }
}
