using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public  class Title
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int titleId { get; set; }
        [StringLength(10)]
        public string title { get; set; }

        [StringLength(30)]
        public string icon { get; set; }
    
        
        public ICollection<Customer> Customers { get; set; }
        
        public ICollection<Title_Lang> Title_Lang { get; set; }
       
        // This Titles Fields In DataBase
        public const int Male = 1;
        public const int Female = 2;
    }
}
