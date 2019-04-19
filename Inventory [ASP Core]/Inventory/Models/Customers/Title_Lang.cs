using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public  class Title_Lang
    {
        [Key]
        public int titleLangId { get; set; }
        public int TitleId { get; set; }

        [StringLength(20)]
        public string title { get; set; }
        public int LanguageId { get; set; }
    
        public Title Title { get; set; }
        public Language Language { get; set; }
    }
}
