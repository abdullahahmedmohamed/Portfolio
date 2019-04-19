using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.GenericClasses.CustomDataAnnotation
{
    public class _GraterThanZero : ValidationAttribute
    {
        
        public override bool IsValid(object value)
        {
            var num = Convert.ToDecimal(value);
            if (num > 0)
                return true;

            return false;
        }

    }
}
