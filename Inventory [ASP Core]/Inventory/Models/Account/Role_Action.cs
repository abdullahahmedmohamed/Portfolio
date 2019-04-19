using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inventory.Models
{
    public class Role_Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int roleActionId { get; set; }
        public bool isAllow { get; set; }
        public long RoleId { get; set; }
        public int ActionId { get; set; }
        public int PageId { get; set; }

        public ApplicationRole Role { get; set; }
        public Action Action { get; set; }
        public Page Page { get; set; }
    }
}
