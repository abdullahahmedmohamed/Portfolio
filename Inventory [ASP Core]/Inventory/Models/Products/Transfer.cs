using System;
using System.Collections.Generic;


namespace Inventory.Models
{
    public class Transfer
    {
        public int transferId { get; set; }
        public DateTime transferDate { get; set; }
        public decimal qty { get; set; }

        public int fromLocation { get; set; }
        public int toLocation { get; set; }

        public bool isDeleted { get; set; }


        // Look At DbContext Class in  OnModelCreating() for foreignkey Configration
        public Location LocationFrom { get; set; }
        public Location LocationTo { get; set; }
        
        public ICollection<Transfer_Details> Transfer_Details { get; set; }
    }
}
