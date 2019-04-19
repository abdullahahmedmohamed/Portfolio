using System;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Customer_Payment
    {
        [Key]
        public int customerPaymentId { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal paymentValue { get; set; }

        [StringLength(250)]
        public string comment { get; set; }
        public bool isDeleted { get; set; }

        public int CustomerId { get; set; }
        public int Payment_MethodId { get; set; }
    
        public Customer Customer { get; set; }
        public Payment_Method Payment_Method { get; set; }
    }
}
