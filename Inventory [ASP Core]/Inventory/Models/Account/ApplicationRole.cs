using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class ApplicationRole : IdentityRole<long>
    {
        [StringLength(250)]
        public string Description { get; set; }
        
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        // This is Main Role => this Role For Programers {Note : I Seed This Role To DataBase in Roles Table}
        /*
            1-every Action is allowed for this role 
            2-Display miniProfiler just for this Role
        */
        public static readonly int SuperAdmin = 1;

        // This Role for System Admin so he can manage the system and have all permissions exclude {Display miniProfiler , Exceptions Logger}
        public static readonly int Admin = 2;
    }
}
