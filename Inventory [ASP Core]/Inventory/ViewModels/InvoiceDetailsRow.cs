using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels
{
    public class InvoiceDetailsRow
    {
        public int rowIndex { get; set; }
        public string productName { get; set; }
        public string code { get; set; }
        public string barcode { get; set; }
        public string companyName { get; set; }
        public string pic { get; set; }
        public string total { get; set; }

        public Dictionary<int, DTOs.Sell_DetailsDto> Sell_DetailsDto { get; set; }
    }
}
