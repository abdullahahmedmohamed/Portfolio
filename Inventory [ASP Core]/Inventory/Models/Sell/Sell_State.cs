using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Sell_State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sellStateId { get; set; }

        [StringLength(15)]
        public string stateName { get; set; }

        [StringLength(50)]
        public string icon { get; set; }
        [StringLength(50)]
        public string cssClass { get; set; }
    
         
        public ICollection<Sell> Sells { get; set; }
        
        public ICollection<Sell_State_Lang> Sell_State_Lang { get; set; }

        //--------------------------------------------------------------------------------------------
        // IDs of Sell States Name (Note It Must Match what in DataBase )
        //--------------------------------------------------------------------------------------------
        public const int New = 1; // New Invoice
        public const int Deleted = 2; // Deleted Invoice
        public const int Refunded = 3; // Refunded Invoice
    }
}
