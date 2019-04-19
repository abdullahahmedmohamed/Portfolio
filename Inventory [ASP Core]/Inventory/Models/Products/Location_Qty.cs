using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public  class Location_Qty
    {
        [Key]
        public int locationQtyId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public decimal qty { get; set; }
    
        public Product Product { get; set; }
        public Location Location { get; set; }
    }
}
