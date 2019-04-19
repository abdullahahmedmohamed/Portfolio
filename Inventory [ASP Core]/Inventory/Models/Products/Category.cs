
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Category
    {
     
        public int categoryId { get; set; }
        [StringLength(50)]
        public string categoryName { get; set; }

        [StringLength(250)]
        public string discription { get; set; }
        public bool isDeleted { get; set; }
        
        public  ICollection<Product> Products { get; set; }
    }
}
