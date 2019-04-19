using System;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Taswya
    {
        public int taswyaId { get; set; }
        public DateTime taswyaDate { get; set; }

        [StringLength(250)]
        public string discription { get; set; }
        public decimal qty { get; set; }
        public bool isDeleted { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
    
        public Location Location { get; set; }
        public Product Product { get; set; }
    }
}
