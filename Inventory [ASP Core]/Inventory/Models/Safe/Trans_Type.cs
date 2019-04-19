using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Trans_Type
    {
        [Key]
        public int transTypeId { get; set; }

        [StringLength(50)]
        public string transType { get; set; }
    
       
        public ICollection<Trans_Type_Lang> Trans_Type_Lang { get; set; }
       
        public ICollection<Safe_Trans> Safe_Trans { get; set; }
    }
}
