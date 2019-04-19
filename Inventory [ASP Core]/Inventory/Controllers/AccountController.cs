using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Inventory.AccountTooles;
using Microsoft.EntityFrameworkCore;
using Inventory.GenericClasses.ManagingFiles;
using Microsoft.Extensions.Localization;
using Inventory.GenericClasses;

namespace Inventory.Controllers
{
    public class AccountController : Controller
    {

        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IStringLocalizer<AccountController> _localizer;
        private AppDbContext _db;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IHostingEnvironment hostingEnvironment, IStringLocalizer<AccountController> localizer, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            _localizer = localizer;
            _db = db;

        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) // Get All Model Errors and Join Them in One Sting Seperated by coma ","
                    throw new ApplicationException(Global.ModelErrorsToJoinString(ModelState, ","));


                // Check if LogIn User Allow To Loggin so he must be Active and not deleted  (isActive==True&&isDeleted==Flase)
                bool Allow = await _db.Users.AnyAsync(u => u.NormalizedUserName == model.UserName.ToUpper() && u.IsDeleted == false && u.IsActive == true);
                if (!Allow) // In Case Not Allowed User 
                    throw new ApplicationException(_localizer["NotAllowedToLoginMsg"]);

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //User.AddIdentity(new System.Security.Claims.Claim("UserBranch", "")); //AddClaim(new Claim(ClaimName.BranchId, user.pic ?? ""));
                    // You Can Set Logger Here Or Update User State To be Online
                    //return RedirectToLocal(returnUrl);
                    return Json(new { msg = _localizer["LoginSuccessfulMsg"], isError = 0 });
                }
                if (result.IsLockedOut)
                {
                    // You Can Set Logger Here Or Update User State To be Locked out =>("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                throw new ApplicationException(_localizer["UserNameOrPasswordNotValidMsg"]);

            }
            catch (ApplicationException ex)
            {
                return Json(new { msg = ex.Message, isError = 1 });
            }
            catch (Exception)
            {
                return Json(new { msg = _localizer["UnknownErrorCallUsMsg"], isError = 1 });
            }



        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //User Initial Settings (Panel of Option Need To Be Fill after login and before accessing the web pages)
        // In Case when user login he want to set some Initial settings for example logged in Employee Want to Choose Department before accessing the web app
        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        [Authorize]
        public async Task<IActionResult> InitialSettings()
        {
            //-------------------------------------------------------------------------------------------------------------
            //  Initializing setting Object with LoggedIn User Data and Available Branches
            //-------------------------------------------------------------------------------------------------------------
            long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var settings = new InitialSettingsViewModel();
            settings.selectedBranchID = Convert.ToInt32(User.FindFirstValue(ClaimName.BranchId));
            settings.UserName = User.Identity.Name;
            settings.UserPic = User.FindFirstValue(ClaimName.pic) ?? "";

            // In Case User Role is SuperAdmin or Admin get All Branches otherwise get allowed Branches for looged in user
            if (User.IsInRole(nameof(ApplicationRole.SuperAdmin)) || User.IsInRole(nameof(ApplicationRole.Admin)))
            {// Get All Branches for Branches Table
                settings.AvailableBranches = await _db.Branches.Where(b => b.isDeleted == false).Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = b.branchId.ToString(), Text = b.branchName }).ToListAsync();
            }
            else
            {   //  get allowed Branches form UserBranches Table
                settings.AvailableBranches = await _db.UserBranches.Include(b => b.Branch).Where(u => u.UserId == userId && u.Branch.isActive && u.Branch.isDeleted == false).Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = b.BranchId.ToString(), Text = b.Branch.branchName }).ToListAsync();
            }


            return PartialView("_InitialSettingsPartial", settings);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitialSettings(int selectedBranchID)
        {
            try
            {
                //-------------------------------------------------------------------------------------------------------------
                //initialize Logged In User Branch (Check if User want to continue with his default branch or changing it)
                //-------------------------------------------------------------------------------------------------------------
                int currentBranchID = Convert.ToInt32(User.FindFirst(ClaimName.BranchId).Value);
                if (currentBranchID != selectedBranchID)
                {

                    long userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    ApplicationUser user;

                    // In Case User Role is SuperAdmin or Admin Dont Validate if user allowed for selected branch
                    if (User.IsInRole(nameof(ApplicationRole.SuperAdmin)) || User.IsInRole(nameof(ApplicationRole.Admin)))
                    { // get user just by id
                        user = await _db.Users.SingleOrDefaultAsync(u => u.Id == userId);
                    }
                    else
                    {// get user just if selected branchId available for this user otherwise get null
                        user = await _db.Users.SingleOrDefaultAsync(u => u.Id == userId && u.UserBranches.Any(b => b.UserId == userId && b.BranchId == selectedBranchID));
                        if (user == null)
                            throw new ApplicationException(_localizer["SelectedBranchNotAllowedMsg"]);

                    }

                    user.BranchId = selectedBranchID;
                    await _db.SaveChangesAsync();
                    await _signInManager.RefreshSignInAsync(user);



                }
                return RedirectToAction("index", "Home");
            }
            catch (ApplicationException appEx)
            {
                return Json(appEx.Message);
            }
            catch (Exception)
            {
                return Json(_localizer["UnknownErrorCallUsMsg"]);
            }
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewData["Roles"] = _roleManager.Roles;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            /*
             ApplicationRole role = new ApplicationRole { Name="developer"};
                try { 
                var res= await _roleManager.CreateAsync(role);
                    if(res.Succeeded)
                    { }
                }
           

                var user = new ApplicationUser { UserName = model.UserName, Email = "admin@site.com" };
                var result2 = await _userManager.CreateAsync(user, model.Password);
                if (result2.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "developer");
                    // You Can Create Logger here ("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                }
             */
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {

                    UserName = model.UserName,
                    Email = model.Email,
                    fullName = model.fullName,
                    idNo = model.idNo,
                    PhoneNumber = model.PhoneNumber,
                    birthDate = model.birthDate,
                    joinDate = model.joinDate,
                    RoleId = model.RoleId

                };


                if (model.pic != null)
                {
                    // Build Directory Path to upload files in this directory 
                    string uploadFolder = Path.Combine( "assets", "images", "users");
                    // Note FileManager , ValidFormat are Custom Class not built in Asp core 
                    string uploadedFileName = await FileManager.UploadFileWithValidationAsync(model.pic, ValidFormat.Img, _hostingEnvironment.WebRootPath, uploadFolder);

                    if (uploadedFileName == null)
                    {
                        ModelState.AddModelError(string.Empty, "Your File Not Valid Please Upload Image {JPG,PNG,GIF} With Max Size is 512KB");
                        ViewData["Roles"] = _roleManager.Roles;
                        return View(model);
                    }

                    user.pic = uploadedFileName;

                }

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    // You Can Create Logger here ("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            ViewData["Roles"] = _roleManager.Roles;
            return View(model);
        }

        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            // You Can Create Logger here ("User logged out.");
            return RedirectToAction(nameof(Login));
        }


        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion




    }
}