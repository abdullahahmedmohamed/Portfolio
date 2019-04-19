using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.ViewModels
{
    public class SellIndexViewModel

    {
        public int SellId { get; set; }
        public DateTime SellDate { get; set; }

        //Customer
        public string CustomerName { get; set; }
        public string CustomerPic { get; set; }

        //Location
        public string LocationName { get; set; }

        
        public decimal TotalPrice { get; set; }
        public decimal TotalQty { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }

        
        public SellStateViewModel SellState { get; set; }
        

        // Total of Rows Count For Pagination
        public int RowsCount { get; set; }



    }

    public class SellStateViewModel
    {
        // Sell_State_Lang Name
        public string LangName { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }
    }
}
