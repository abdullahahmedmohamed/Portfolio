using System;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class Expenses
    {
        public int expensesId { get; set; }
        public decimal value { get; set; }
        public DateTime expensesDate { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        public int Expenses_TypeId { get; set; }
        public bool isDeleted { get; set; }
        public int BranchId { get; set; }
    
        public Expenses_Type Expenses_Type { get; set; }
        public Branch Branch { get; set; }
    }
}
