
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Customer
    {
        
        public int customerId { get; set; }

        [StringLength(50)]
        public string customerName { get; set; }

        [StringLength(260)]
        public string pic { get; set; }

        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        
        [StringLength(14)]
        public string idNo { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(11)]
        public string phone { get; set; }
        [StringLength(11)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(11)]
        public string fax { get; set; }

        [StringLength(50)]
        public string companyName { get; set; }

        public decimal openAccount { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        
        public int TitleId { get; set; }
        public int DiscountId { get; set; }
        public int TaxId { get; set; }

        public Title Title { get; set; }
        public Discount Discount { get; set; }
        public Tax Tax { get; set; }
        
    }
}
