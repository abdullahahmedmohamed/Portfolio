
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Expenses_Type
    {
        [Key]
        public int expensesTypeId { get; set; }

        [StringLength(60)]
        public string type { get; set; }
        public bool isDeleted { get; set; }
    
        
        public ICollection<Expenses> Expenses { get; set; }
    }
}
