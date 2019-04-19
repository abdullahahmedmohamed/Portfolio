using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public  class Language
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int languageId { get; set; }
        [StringLength(20)]
        public string languageName { get; set; }
    
        public ICollection<Action_Lang> Action_Lang { get; set; }
    
        public ICollection<Page_Lang> Page_Lang { get; set; }

        
        public ICollection<Payment_Method_Lang> Payment_Method_Lang { get; set; }

        public ICollection<Buy_State_Lang> Buy_State_Lang { get; set; }

        public ICollection<Trans_Type_Lang> Trans_Type_Lang { get; set; }

        public ICollection<Sell_State_Lang> Sell_State_Lang { get; set; }

        public ICollection<Title_Lang> Title_Lang { get; set; }


    }
}
