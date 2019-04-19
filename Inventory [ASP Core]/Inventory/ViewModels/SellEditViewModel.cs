using Inventory.DTOs;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels
{
    public class SellEditViewModel
    {
        public SellDto SellDto { get; set; }
        public string CustomerName { get; set; }
        public bool IsDeletedSell { get; set; }
        public List<InvoiceDetailsRow> Sell_DetailsDto { get; set; }
        public ICollection<Location> Locations { get; set; }
    }

}
