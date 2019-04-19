using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        [StringLength(50)]
        public string fullName { get; set; }

        [StringLength(14)]
        public string idNo { get; set; }

        [StringLength(260)]
        public string pic { get; set; }

        public DateTime joinDate { get; set; }
        public DateTime birthDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public long RoleId { get; set; }
        public int BranchId { get; set; }

        public  ApplicationRole Role { get; set; }
        public Branch Branch { get; set; }
        public  ICollection<UserBranch> UserBranches { get; set; }
    }
}
