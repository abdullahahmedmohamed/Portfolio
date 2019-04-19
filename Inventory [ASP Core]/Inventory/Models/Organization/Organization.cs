
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orgId { get; set; }

        [StringLength(50)]
        public string orgName { get; set; }

        [StringLength(150)]
        public string website { get; set; }

        [StringLength(100)]
        public string mainEmail { get; set; }

        [StringLength(260)]
        public string logo { get; set; }

        public ICollection<Branch> Branches { get; set; }

    }
}
