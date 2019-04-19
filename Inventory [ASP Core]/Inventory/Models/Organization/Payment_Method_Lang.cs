
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{

    public class Payment_Method_Lang
    {
        [Key]
        public int paymentMethodLangId { get; set; }

        [StringLength(50)]
        public string paymentMethod { get; set; }

        public int Payment_MethodId { get; set; }
        public int LanguageId { get; set; }
    
        public Language Language { get; set; }
        public Payment_Method Payment_Method { get; set; }
    }
}
