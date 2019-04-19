using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Page_Lang
    {
        [Key]
        public int pageLangId { get; set; }
       
        [StringLength(50)]
        public string pageTitle { get; set; }
        [StringLength(250)]
        public string discription { get; set; }
        

        public int PageId { get; set; }
        public int LanguageId { get; set; }

        public Page Page { get; set; }
        public Language Language { get; set; }
    }
}
