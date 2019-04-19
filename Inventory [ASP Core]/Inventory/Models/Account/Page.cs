using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{


    public class Page
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pageId { get; set; }
        [StringLength(50)]
        public string pageTitle { get; set; }


        public ICollection<Role_Action> RoleActions { get; set; }

        public ICollection<Page_Lang> Page_Lang { get; set; }

        public ICollection<AuditTrial> AuditTrials { get; set; }

        // Pages {Note : Pages Name In Db Must Match Controllers Names For Example if you have "CustomerController" you must have Page Name "customer" In Db} i'm using this convention in Authorization Validation to check if user Have Permission To Read/Edit/Insert/Delete

        //public static ReadOnlyDictionary< string, int> PageNames = new ReadOnlyDictionary<string, int>(new Dictionary<string, int>
        //{
        //    { "home"        ,1 },

        //    { "account"     ,2 },

        //    { "customers"   ,3 },

        //    { "products"    ,4 },

        //    { "suppliers"   ,5 },

        //    { "sell"        ,6 },

        //    { "buy"         ,7 },

        //    { "transfers"   ,8 },

        //    { "safe"        ,9 },

        //    { "expenses"    ,10 },

        //    { "settings"    ,11 },


        //});


        //public const int HomePage = 1;
        //public const int AccountPage = 2;
        //public const int Customers = 3;
        //public const int products = 4;
        //public const int Suppliers = 5;
        //public const int Sell = 6;
        //public const int Buy = 7;
        //public const int Transfers = 8;
        //public const int Safe = 9;
        //public const int Settings = 11;
        //public const int Expenses = 10;

        public enum Pages
        {
            home = 1,

            account = 2,

            customers = 3,

            products = 4,

            suppliers = 5,

            sell = 6,

            buy = 7,

            transfers = 8,

            safe = 9,

            expenses = 10,

            settings = 11,

            taswya = 12 

        }
    }
}
