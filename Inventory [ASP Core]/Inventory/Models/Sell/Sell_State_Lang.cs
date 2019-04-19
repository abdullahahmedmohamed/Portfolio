using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public  class Sell_State_Lang
    {
        [Key]
        public int sellStateLangId { get; set; }
        
        [StringLength(50)]
        public string stateName { get; set; }

        public int Sell_StateId { get; set; }
        public int LanguageId { get; set; }
    
        public Sell_State Sell_State { get; set; }
        public Language Language { get; set; }
    }
}
