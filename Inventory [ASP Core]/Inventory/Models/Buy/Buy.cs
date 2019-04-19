using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Buy
    {
      
    
        public int buyId { get; set; }
        public DateTime buyDate { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        public decimal totalPrice { get; set; }
        public decimal totalQty { get; set; }
        
        public decimal discount { get; set; }
        public decimal tax { get; set; }

        [StringLength(50)]
        public string supplierCode { get; set; }

        [StringLength(260)]
        public string docment { get; set; }

        public bool isPercentTax { get; set; }
        public bool isPercentDiscount { get; set; }
        public bool isReturn { get; set; }
        public bool isAgel { get; set; }

        public int Buy_StateId { get; set; }
        public int SupplierId { get; set; }
        public int LocationId { get; set; }
    
        public Buy_State Buy_State { get; set; }
        public Supplier Supplier { get; set; }
        public Location Location { get; set; }
        public ICollection<Buy_Details> Buy_Details { get; set; }
    }
}
