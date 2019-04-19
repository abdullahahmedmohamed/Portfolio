using Inventory.GenericClasses.CustomDataAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.DTOs
{
    public class Sell_DetailsDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [_GraterThanZero]
        public decimal qty { get; set; }

        public decimal unitPrice { get; set; }

        [_ValidSellDetailsDiscount]
        public decimal discount { get; set; }

        public bool isPercentDiscount { get; set; }

       
    }
}


