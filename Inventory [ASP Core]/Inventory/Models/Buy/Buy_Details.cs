
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Buy_Details
    {
        [Key]
        public int buyDetailsId { get; set; }
       
        public decimal qty { get; set; }
        public decimal unitPrice { get; set; }
        public decimal discount { get; set; }
        public bool isPercentDiscount { get; set; }

        public int BuyId { get; set; }
        public int ProductId { get; set; }
    
        public Buy Buy { get; set; }
        public Product Product { get; set; }
    }
}
