using Inventory.GenericClasses.ManagingFiles;
using Inventory.GenericClasses.CustomDataAnnotation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.DTOs
{
    public class SellDto
    {
        public int sellId { get; set; }

        [Display(Name = "Sell Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime sellDate { get; set; }
        public string comment { get; set; }

      
        [_ValidSellDiscount(ErrorMessage="Discount Amount Have To Be In Range (0% to 100%) in Percentage Case or (0) or Higher In Case None Percentage")]
        public decimal discount { get; set; }

        [_ValidSellTax(ErrorMessage="Tax Amount Have To Be In Range (0% to 100%) in Percentage Case or (0) or Higher In Case None Percentage")]
        public decimal tax { get; set; }

        [_ValidFile(ValidFormat.MixDocImg, ErrorMessage="Please attach a file of the following types [{0}] with size not Exceed {1} Kb")]
        public IFormFile docment { get; set; }

        
        public bool isPercentDiscount { get; set; }
        public bool isPercentTax { get; set; }
        public bool isReturn { get; set; }
        public bool isAgel { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int CustomerId { get; set; }

        [_ListMinimumCount(1, ErrorMessage = "At least One Sell Details is required")]
        public List<Sell_DetailsDto> Sell_DetailsDto { get; set; }

     

    }

}
