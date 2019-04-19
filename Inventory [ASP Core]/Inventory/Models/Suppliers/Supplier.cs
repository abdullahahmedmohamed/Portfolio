using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Supplier
    {
        
        public int supplierId { get; set; }

        [StringLength(50)]
        public string supplierName { get; set; }

        [StringLength(260)]
        public string pic { get; set; }

        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        [StringLength(50)]
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
        public string website { get; set; }

        [StringLength(50)]
        public string companyName { get; set; }
        public decimal openAccount { get; set; }

        [StringLength(250)]
        public string comment { get; set; }
    
        
        public ICollection<Supplier_Payment> Supplier_Payment { get; set; }
        public ICollection<Buy> Buys { get; set; }
    }
}
