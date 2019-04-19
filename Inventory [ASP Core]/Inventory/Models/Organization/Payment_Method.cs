
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{

    public class Payment_Method
    {

        [Key]
        public int paymentMethodId { get; set; }
        [StringLength(50)]
        public string paymentMethod { get; set; }

        [StringLength(50)]
        public string icon { get; set; }

        [StringLength(50)]
        public string cssClass { get; set; }
    
        
        public ICollection<Payment_Method_Lang> Payment_Method_Lang { get; set; }
        
        public ICollection<Customer_Payment> Customer_Payment { get; set; }
       
        public ICollection<Supplier_Payment> Supplier_Payment { get; set; }
    }
}
