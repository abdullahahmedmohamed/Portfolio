using System;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Supplier_Payment
    {
        [Key]
        public int supplierPaymentId { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal paymentValue { get; set; }
        
        [StringLength(250)]
        public string comment { get; set; }
        public bool isDeleted { get; set; }

        public int SupplierId { get; set; }
        public int Payment_MethodId { get; set; }
    
        public Supplier Supplier { get; set; }
        public Payment_Method Payment_Method { get; set; }
    }
}
