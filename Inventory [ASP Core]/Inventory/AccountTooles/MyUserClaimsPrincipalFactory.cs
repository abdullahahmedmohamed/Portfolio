using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Inventory.Models;

namespace Inventory.AccountTooles
{
    //--------------------------------------------------------------------------------------------------------------------------
    // Asp identity set some basic and default claims to any logged in user like id and userName , SecurityStamp ...
    // 
    //Here i'm Adding Some Custom Claims :
    //      1- Adding Some Main Data like img src or maybe user realName
    //      2- Adding list of Allowed Role_Actions based of User Role so its easy to vlidate it via Claims instead of DB
    //Note:
    // in Startup.cs file use : services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();
    //--------------------------------------------------------------------------------------------------------------------------
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        private AppDbContext db;

        public MyUserClaimsPrincipalFactory(
            AppDbContext _db,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
            db = _db;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            //----------------------------------------------------------------------------------------------------------------------
            // Base and Defual Asp identity Claims
            //----------------------------------------------------------------------------------------------------------------------
            var identity = await base.GenerateClaimsAsync(user);

            //----------------------------------------------------------------------------------------------------------------------
            // Adding Some Main Data like img src or maybe user realName in The Claims (business requirements)
            //----------------------------------------------------------------------------------------------------------------------

            //GetUserBranch
            string branchName = db.Branches.Where(b => b.branchId == user.BranchId).Select(b => b.branchName).SingleOrDefault();
            identity.AddClaim(new Claim(ClaimName.BranchId, user.BranchId.ToString()));
            identity.AddClaim(new Claim(ClaimName.BranchName, branchName));

            //GetUserPicture
            identity.AddClaim(new Claim(ClaimName.pic, user.pic ?? ""));

            //----------------------------------------------------------------------------------------------------------------------
            //Adding list of Allowed Role_Actions based of User Role so its easy to vlidate it via Claims instead of DB
            //Note : Allowed Role_Actions Only so all Role_Actions that not allowed for this User not Entered
            //----------------------------------------------------------------------------------------------------------------------

            var allowedActions = await db.Role_Action.Where(r => r.RoleId == user.RoleId && r.isAllow == true).Select(r => new MyRolesAcctions { pageTitle = r.Page.pageTitle, actionName = r.Action.actionName }).ToListAsync();

            foreach (MyRolesAcctions action in allowedActions)
            {
                string ClaimName = String.Format("{0}_{1}", action.pageTitle, action.actionName).ToLower();
                identity.AddClaim(new Claim(ClaimName, "1"));

            }
            return identity;
        }


    }

    // encapsulated Class For Main Data That i Need To Create Claim Name And its value
    class MyRolesAcctions
    {
        public string pageTitle { get; set; }
        public string actionName { get; set; }

    }

    public class ClaimName
    {
        public const string BranchId = "branchId";
        public const string BranchName = "branchName";
        public const string pic = "pic";
        public const string fullName = "fullName";
    }

}
