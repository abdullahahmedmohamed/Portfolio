using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inventory.Models
{

    public class Branch
    {
        
        public int branchId { get; set; }

        [StringLength(50)]
        public string branchName { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(11)]
        public string mobiles { get; set; }

        [StringLength(11)]
        public string phones { get; set; }

        [StringLength(11)]
        public string faxs { get; set; }

        [StringLength(50)]
        public string email { get; set; }
        public DateTime openDate { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
    
        public Organization Organization { get; set; }
        
        public ICollection<Expenses> Expenses { get; set; }
        
        public ICollection<Location> Locations { get; set; }
        
        public ICollection<Safe> Safes { get; set; }
    }
}
