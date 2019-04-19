using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inventory.Models
{
    public class Action
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int actionId { get; set; }

        [StringLength(20)]
        public string actionName { get; set; }

        public ICollection<Role_Action> RoleActions { get; set; }
        public ICollection<AuditTrial> AuditTrials { get; set; }
        public ICollection<Action_Lang> Action_Lang { get; set; }

        // This CRUD Operations Id In DataBase
        public const int Create = 1;
        public const int Read = 2;
        public const int Update = 3;
        public const int Delete = 4;

        
    }
}
