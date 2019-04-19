
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Brand
    {
        [Key]
        public int brandId { get; set; }
        [StringLength(50)]
        public string companyName { get; set; }
        public bool isDeleted { get; set; }
    
        
        public ICollection<Product> Products { get; set; }
    }
}
