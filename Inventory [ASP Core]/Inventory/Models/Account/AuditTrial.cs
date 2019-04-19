using System;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{

    public  class AuditTrial
    {
        [Key]
        public int auditId { get; set; }
        public DateTime actionDate { get; set; }
        public int recordId { get; set; }

        public int ActionId { get; set; }
        public long UserId { get; set; }
        public int PageId { get; set; }

        public Action Action { get; set; }
        public ApplicationUser User { get; set; }
        public Page Page { get; set; }
    }
}
