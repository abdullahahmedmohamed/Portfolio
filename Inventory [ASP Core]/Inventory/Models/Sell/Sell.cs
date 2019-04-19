using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Sell
    {
        public int sellId { get; set; }
        public DateTime sellDate { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        public decimal totalPrice { get; set; }
        public decimal totalQty { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        

        [StringLength(260)]
        public string docment { get; set; }

        public bool isPercentDiscount { get; set; }
        public bool isPercentTax { get; set; }
        public bool isReturn { get; set; }
        public bool isAgel { get; set; }
        public bool isDeleted { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int Sell_StateId { get; set; }

        public Sell_State Sell_State { get; set; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Sell_Details> Sell_Details { get; set; }
    }
}
