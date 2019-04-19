
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Safe
    {

        public int safeId { get; set; }

        [StringLength(50)]
        public string safeName { get; set; }
        public bool isDeleted { get; set; }

        [StringLength(250)]
        public string comment { get; set; }
        public int BranchId { get; set; }
    
        public Branch Branch { get; set; }
        public ICollection<Safe_Trans> Safe_Trans { get; set; }
    }
}
