using Inventory.GenericClasses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.DTOs
{
    public class _ValidSellDiscount : ValidationAttribute
    {
     
        //---------------------------------------------------------------------------------------------------------------
        // Discount or Tax Amount  in case isPercentage must be from 0% to 100% and in any case must be not less than 0
        //---------------------------------------------------------------------------------------------------------------

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            SellDto sellDto = (SellDto)validationContext.ObjectInstance;
            decimal discountAnount = sellDto.discount;
            bool isPercentage = sellDto.isPercentDiscount;

            if ((discountAnount < 0)||(isPercentage && discountAnount > 100))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;

        }
    }
}
