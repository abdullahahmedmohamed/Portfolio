using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Transfer_Details
    {
        [Key]
        public int transferDetailsId { get; set; }
        public int ProductId { get; set; }
        public decimal qty { get; set; }
        public int TransferId { get; set; }
    
        public Product Product { get; set; }
        public Transfer Transfer { get; set; }
    }
}
