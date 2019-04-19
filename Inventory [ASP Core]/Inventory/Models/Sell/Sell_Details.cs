using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Sell_Details
    {
        [Key]
        public int sellDetailsId { get; set; }
        public decimal unitPrice { get; set; }
        public decimal qty { get; set; }
        public decimal discount { get; set; }
        public int SellId { get; set; }
        public bool isPercentDiscount { get; set; }
        public int ProductId { get; set; }
    
        public Sell Sell { get; set; }
        public Product Product { get; set; }
    }
}
