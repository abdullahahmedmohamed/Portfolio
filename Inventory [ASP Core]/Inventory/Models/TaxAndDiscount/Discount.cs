using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Discount
    {
        
        public int discountId { get; set; }

        [StringLength(50)]
        public string title { get; set; }
        public decimal discountValue { get; set; }
        public bool isDeleted { get; set; }
        public bool isPercent { get; set; }
    
        
        public ICollection<Customer> Customers { get; set; }
    }
}
