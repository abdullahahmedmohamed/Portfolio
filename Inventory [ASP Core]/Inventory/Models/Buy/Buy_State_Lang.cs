using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Buy_State_Lang
    {
        [Key]
        public int buyStateLangId { get; set; }

        [StringLength(60)]
        public string stateName { get; set; }

        public int Buy_StateId { get; set; }
        public int LanguageId { get; set; }
    
        public Buy_State Buy_State { get; set; }
        public Language Language { get; set; }
    }
}
