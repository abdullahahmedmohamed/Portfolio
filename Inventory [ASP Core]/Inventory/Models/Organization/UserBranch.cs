

namespace Inventory.Models
{

    public class UserBranch
    {
        public int UserBranchId { get; set; }
        public long UserId { get; set; }
        public int BranchId { get; set; }

    
        public virtual ApplicationUser User { get; set; }
        public virtual Branch Branch { get; set; }

        
    }
}
