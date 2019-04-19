using Inventory.GenericClasses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.DTOs
{
    public class _ValidSellDetailsDiscount : ValidationAttribute
    {
        //---------------------------------------------------------------------------------------------------------------
        // Discount OR Tax Amount  in case isPercentage must be from 0% to 100% and in any case must be not less than 0
        //---------------------------------------------------------------------------------------------------------------
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Sell_DetailsDto sell_DetailsDto = (Sell_DetailsDto)validationContext.ObjectInstance;
            decimal discountAnount = sell_DetailsDto.discount;
            bool isPercentage = sell_DetailsDto.isPercentDiscount;
            
            if (discountAnount < 0)
                return new ValidationResult("Discount Amount For Sell Details Item Have To Be (0) or Higher");

            if (isPercentage && discountAnount > 100)
                return new ValidationResult("Discount Amount For Sell Details Item Have To Be In Range (0% to 100%)");
            
            return ValidationResult.Success;

        }
    }
}
