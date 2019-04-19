
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{

    public class Action_Lang
    {
        [Key]
        public int actionLangId { get; set; }

        [StringLength(250)]
        public string discription { get; set; }

        [StringLength(20)]
        public string actionName { get; set; }
        public int ActionId { get; set; }
        public int LanguageId { get; set; }
    
        public Action Action { get; set; }
        public Language Language { get; set; }
    }
}
