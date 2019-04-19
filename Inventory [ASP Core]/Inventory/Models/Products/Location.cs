using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Location
    {
        
        [Key]    
        public int locationId { get; set; }

        [StringLength(50)]
        public string locationname { get; set; }

        [StringLength(250)]
        public string discription { get; set; }

        public bool isDeleted { get; set; }

        public int BranchId { get; set; }
        
        public Branch Branch { get; set; }
        public  ICollection<Location_Qty> Location_Qty { get; set; }
        public  ICollection<Transfer> TransfersFrom { get; set; }
        public  ICollection<Transfer> TransfersTo { get; set; }
        public  ICollection<Taswya> Taswyas { get; set; }
        public  ICollection<Buy> Buys { get; set; }
        public  ICollection<Sell> Sells { get; set; }
    }
}
