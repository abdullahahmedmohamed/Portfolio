
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Buy_State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int buyStateId { get; set; }

        [StringLength(15)]
        public string stateName { get; set; }

        [StringLength(50)]
        public string icon { get; set; }

        [StringLength(50)]
        public string cssClass { get; set; }
    
        
        public ICollection<Buy> Buys { get; set; }
        
        public ICollection<Buy_State_Lang> Buy_State_Lang { get; set; }

        //--------------------------------------------------------------------------------------------
        // IDs of Buy States Name (Note It Must Match what in DataBase )
        //--------------------------------------------------------------------------------------------
        public const int New = 1; // New Invoice
        public const int Deleted = 2; // Deleted Invoice
        public const int Refunded = 3; // Refunded Invoice
        public const int Initial = 4; // Initial Invoice
    }
}
