using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Action = Inventory.Models.Action;
namespace Inventory.AccountTooles
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //This Class is responsible for determining whether a logged in user has the authority to read data for a particular page{controller} or to edit, insert, or delete records for this page
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public static class UserPagePermission
    {
        private static string getActionName(int actionID)
        {
            string actionName = "";

            switch (actionID)
            {
                case Action.Read: actionName = nameof(Action.Read); break;   // assign "Read" word
                case Action.Create: actionName = nameof(Action.Create); break; // assign "Create" word
                case Action.Update: actionName = nameof(Action.Update); break; // assign "Update" word
                case Action.Delete: actionName = nameof(Action.Delete); break; // assign "Delete" word
                default:
                    actionName = "";
                    break;
            }
            return actionName;
        }

        //----------------------------------------------------------------------------------------
        // PageActionPermission by Claims Authorization => 
        //
        //  Validate if logged In User Authorized for Requested Contrroler.Action example => Customer/Index
        //  Check if this user have Claim that equal pageName_action or not for example => customer_read
        //----------------------------------------------------------------------------------------
        public static bool PageActionPermission(ClaimsPrincipal User, string PageName, int actionID)
        {
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Check if User in Role SuperAdmin or Admin so its always have permission other otherwise check on its permission for this specific page and requested action
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            string SuperAdminRole = nameof(ApplicationRole.SuperAdmin);
            string AdminRole = nameof(ApplicationRole.Admin);
            if (User.IsInRole(SuperAdminRole) || User.IsInRole(AdminRole))
                return true;
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //-----------------------------------------------------------------------
            // Generate Action Name whether it's read / create / update / delete
            //-----------------------------------------------------------------------
            string action = getActionName(actionID);


            //-------------------------------------------------------------------------------------------------------------------
            // Concatenat PageName with Action Name (Note Page Name Must Equal Controller Name) : example => customer_create
            //-------------------------------------------------------------------------------------------------------------------
            string pageAction = String.Format("{0}_{1}", PageName, action).ToLower();

            //-------------------------------------------------------------------------------------------------------------------
            // Check If Current User Have a Claim like "customer_create" that mean he have permission otherwise it's not allowed 
            //-------------------------------------------------------------------------------------------------------------------

            if (User.HasClaim(c => c.Type == pageAction))
                return true;

            return false;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Get Page Permissions {CanCreate,CanUpdate,CanDelete} For Logged In User In Specific Page
        // Note: All Logic here based on MyUserClaimsPrincipalFactory.cs that i used to build list of Allowed Role_Actions based of User Role in Claims with Convention (pageName_action)
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static Permissions GetPagePermissions(ClaimsPrincipal User, string PageName)
        {
            Permissions permissions;
            string SuperAdminRole = nameof(ApplicationRole.SuperAdmin);
            string AdminRole = nameof(ApplicationRole.Admin);

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Check if User in Role SuperAdmin or Admin so its always have permission other otherwise check on its permission 
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (User.IsInRole(SuperAdminRole) || User.IsInRole(AdminRole))
            {
                permissions = new Permissions { CanCreate = true, CanUpdate = true, CanDelete = true, };
            }
            else
            {
                //-------------------------------------------------------------------------------------------------------------------
                // Concatenat PageName with Action Name (Note Page Name Must Equal Controller Name) : example => customer_create
                //-------------------------------------------------------------------------------------------------------------------
                string pageReadAction = String.Format("{0}_{1}", PageName, nameof(Action.Read)).ToLower();
                string pageCreateAction = String.Format("{0}_{1}", PageName, nameof(Action.Create)).ToLower();
                string pageUpdateAction = String.Format("{0}_{1}", PageName, nameof(Action.Update)).ToLower();
                string pageDeleteAction = String.Format("{0}_{1}", PageName, nameof(Action.Delete)).ToLower();
                //-------------------------------------------------------------------------------------------------------------------
                // Check If Current User Have a Claim like "customer_create" that mean he have permission otherwise it's not allowed 
                //-------------------------------------------------------------------------------------------------------------------

                permissions = new Permissions
                {
                    CanCreate = User.HasClaim(c => c.Type == pageCreateAction),
                    CanUpdate = User.HasClaim(c => c.Type == pageUpdateAction),
                    CanDelete = User.HasClaim(c => c.Type == pageDeleteAction)
                };
            }

            return permissions;

        }


    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //the main purpose of this class is to send it to view page so by javaScript i can remove links like add or edit or delete based on Permission values 
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public class Permissions
    {
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
