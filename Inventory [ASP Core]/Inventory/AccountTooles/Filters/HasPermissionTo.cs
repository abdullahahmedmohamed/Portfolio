using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;


namespace Inventory.AccountTooles.Filters
{
    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Check If LogedIn User have Permission by his Role To Access specific Action like (Read/Create/Update/Delete) 
    // in Startup.cs file use : services.AddScoped<HasPermissionTo>();
    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public class HasPermissionTo : IAsyncActionFilter
    {
        public int actionID { get; set; }
        private AppDbContext db;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public HasPermissionTo(int id, AppDbContext _db, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this.actionID = id;
            db = _db;
            userManager = _userManager;
            signInManager = _signInManager;

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var User = context.HttpContext.User;

            string PageName = context.RouteData.Values["controller"].ToString();

            var userId = Convert.ToInt32(userManager.GetUserId(User));
            bool isAllow = false;

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Check if SecurityStamp for this User in Db equal SecurityStamp in his Claims or not
            //      Case 1 : they equal in value => That Mean User Claims Are Valid and i can validate permission via claims
            //      Case 2 : they not equal      => That Mean User Claims Are not Valid (Maybe his role are changed or other importatn value) so i have to make Current User SingOut and Login Again
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            string claim_SecurityStamp = User.FindFirst("AspNet.Identity.SecurityStamp").Value;

            string db_SecurityStamp = await db.Users.Where(u => u.Id == userId).Select(u => u.SecurityStamp).FirstOrDefaultAsync();

            if (claim_SecurityStamp != db_SecurityStamp)
            {
                await signInManager.SignOutAsync();
                context.Result = new RedirectToActionResult("Login", "Account", new { });
                return;
            }
            else // Check if Current User have Permission for Specific action in page via Claims based Authorization
                isAllow = UserPagePermission.PageActionPermission(User, PageName, this.actionID);

            if (!isAllow)
            {
                context.HttpContext.Response.StatusCode = 401; //Unauthorized
                return;
            }


            // execute any code before the action executes
            var result = await next();
            // execute any code after the action executes
        }

    }

}