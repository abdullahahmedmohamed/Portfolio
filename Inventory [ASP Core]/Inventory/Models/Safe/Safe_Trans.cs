using System;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Safe_Trans
    {
        [Key]
        public int safeTransId { get; set; }
                
        public decimal value { get; set; }
        public DateTime transDate { get; set; }
        public bool isDeleted { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        public int SafeId { get; set; }
        public int Trans_TypeId { get; set; }

        public Safe Safe { get; set; }
        public Trans_Type Trans_Type { get; set; }
    }
}
