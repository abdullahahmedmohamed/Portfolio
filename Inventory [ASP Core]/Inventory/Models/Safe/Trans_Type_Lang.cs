using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Trans_Type_Lang
    {
        [Key]
        public int transTypeLangId { get; set; }

        [StringLength(50)]
        public string transType { get; set; }
        public int Trans_TypeId { get; set; }
        public int LanguageId { get; set; }
    
        public Trans_Type Trans_Type { get; set; }
        public Language Language { get; set; }
    }
}
