using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Product
    {
    
        public int productId { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        [StringLength(250)]
        public string discription { get; set; }

        public decimal price { get; set; }

        [StringLength(260)]
        public string pic { get; set; }

        public bool isDeleted { get; set; }
        public bool isActive { get; set; }

        [StringLength(25)]
        public string code { get; set; }

        [StringLength(25)]
        public string barcode { get; set; }

        [StringLength(260)]
        public string pic2 { get; set; }
        [StringLength(260)]
        public string pic3 { get; set; }
        [StringLength(260)]
        public string pic4 { get; set; }

        public Nullable<DateTime> expiryDate { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }


        public Category Category { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Location_Qty> Location_Qty { get; set; }
        public ICollection<Transfer_Details> Transfer_Details { get; set; }
        public ICollection<Taswya> Taswyas { get; set; }
        public ICollection<Sell_Details> Sell_Details { get; set; }
        public ICollection<Buy_Details> Buy_Details { get; set; }
    }
}
