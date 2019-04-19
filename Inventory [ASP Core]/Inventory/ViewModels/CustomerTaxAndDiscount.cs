using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels
{
    public class CustomerTaxAndDiscount
    {
        public decimal taxValue { get; set; }
        public decimal discountValue { get; set; }
        public bool isTaxPrecent { get; set; }
        public bool isDiscountPrecent { get; set; }
    }
}
