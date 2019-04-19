using Inventory.GenericClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Action = Inventory.Models.Action;

namespace Inventory.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //---------------------------------------------------------------------------
        // Account System : (Note we Use Asp Identity Tables)
        //---------------------------------------------------------------------------
        public DbSet<AuditTrial> AuditTrials { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Action_Lang> Action_Lang { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Page_Lang> Page_Lang { get; set; }
        public DbSet<Role_Action> Role_Action { get; set; }

        //---------------------------------------------------------------------------
        // Customers
        //---------------------------------------------------------------------------
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Customer_Payment> Customer_Payments { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Title_Lang> Title_Langs { get; set; }

        //---------------------------------------------------------------------------
        // Suppliers
        //---------------------------------------------------------------------------
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supplier_Payment> Supplier_Payments { get; set; }

        //---------------------------------------------------------------------------
        // Expenses
        //---------------------------------------------------------------------------
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Expenses_Type> Expenses_Types { get; set; }

        //---------------------------------------------------------------------------
        // Organization
        //---------------------------------------------------------------------------
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<Payment_Method> Payment_Methods { get; set; }
        public DbSet<Payment_Method_Lang> Payment_Method_Langs { get; set; }


        //---------------------------------------------------------------------------
        // Products
        //---------------------------------------------------------------------------
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Location_Qty> Location_Qty { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Taswya> Taswya { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
        public DbSet<Transfer_Details> Transfer_Details { get; set; }

        //---------------------------------------------------------------------------
        // Tax And Discount
        //---------------------------------------------------------------------------
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        //---------------------------------------------------------------------------
        // Safe
        //---------------------------------------------------------------------------
        public DbSet<Safe> Safe { get; set; }
        public DbSet<Safe_Trans> Safe_Trans { get; set; }
        public DbSet<Trans_Type> Trans_Types { get; set; }
        public DbSet<Trans_Type_Lang> Trans_Type_Langs { get; set; }

        //---------------------------------------------------------------------------
        // Buy
        //---------------------------------------------------------------------------
        public DbSet<Buy> Buy { get; set; }
        public DbSet<Buy_Details> Buy_Details { get; set; }
        public DbSet<Buy_State> Buy_States { get; set; }
        public DbSet<Buy_State_Lang> Buy_State_Langs { get; set; }

        //---------------------------------------------------------------------------
        // Sell
        //---------------------------------------------------------------------------
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Sell_Details> Sell_Details { get; set; }
        public DbSet<Sell_State> Sell_States { get; set; }
        public DbSet<Sell_State_Lang> Sell_State_Langs { get; set; }

        /*********************************************************************************************/
        /*********************************************************************************************/

        protected override void OnModelCreating(ModelBuilder builder)
        { // Add Identity related model configuration

            base.OnModelCreating(builder);

            // Your fluent modeling here

            //---------------------------------------------------------------------------
            // Set decimal precision for all decimal in our Models
            //---------------------------------------------------------------------------
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal)))
            {
                property.Relational().ColumnType = "decimal(18,2)";
            }

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //         +++++++++++++++++++++ 
            // ------> |    Relationships   | <------
            //         +++++++++++++++++++++
            //Note ( Cascade Vs Restrict ): If you set the relation ship to be ON DELETE CASCADE, when you run a DELETE statement on a parent table it will DELETE all the corresponding rows from the CHILD table automatically. But the RESTRICT (which is the default foreign key relationship behavior) is when you try to delete a row from the parent table and there is a row in the child table with the same ID, it will fail complaining about the existing child rows.
            //---------------------------------------------------------------------------
            builder.Entity<ApplicationUser>()
                        .HasOne(u => u.Role)
                        .WithMany(r => r.Users)
                        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.UserBranches)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transfer>()
           .HasOne(t => t.LocationFrom)
           .WithMany(l => l.TransfersFrom);

            builder.Entity<Transfer>()
           .HasOne(t => t.LocationTo)
           .WithMany(l => l.TransfersTo);

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //         +++++++++++++++++++++ 
            // ------> |non-clustered index| <------
            //         +++++++++++++++++++++
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

            builder.Entity<Product>()
            .HasIndex(t => new { t.productName, t.BrandId, t.isDeleted, t.isActive, t.barcode, t.code });

            //This Index Save most of query execution time when i query to get qty based on productId and locationId
            builder.Entity<Location_Qty>()
            .HasIndex(t => new { t.ProductId, t.LocationId, t.qty });

            builder.Entity<Customer>()
            .HasIndex(t => new { t.customerName, t.isDeleted, t.isActive });

            builder.Entity<Supplier>()
            .HasIndex(t => new { t.supplierName, t.isDeleted, t.isActive });


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //         +++++++++++++++++++++ 
            // ------> |  Seed Basic Data  | <------
            //         +++++++++++++++++++++
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------



            //---------------------------------------------------------------------------
            // Seed Orgnization with Main Branch and One Location
            //---------------------------------------------------------------------------
            builder.Entity<Organization>().HasData(new Organization
            {
                orgId = 1,
                orgName = "Organization",
                mainEmail = "Organization@Organization.org",
                website = "https://www.Organization.org",
                logo = @"/assets/images/shop.png",

            }
            );

            builder.Entity<Branch>().HasData(new Branch
            {
                branchId = 1,
                OrganizationId = 1,
                branchName = "MainBranch",
                isActive = true,
                isDeleted = false,
                openDate = DateTime.Now,
            });

            builder.Entity<Location>().HasData(new Location
            {
                locationId=1,
                BranchId = 1,//MainBranch
                isDeleted = false,
                locationname = "MainBranch-A",
            });

             //------------------------------------------------------------------------------------------------------------------------------------------------------
            // Seed DataBase with all Languages or all supportedCultures example =>  languageId= 1 , languageName="en-US"
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            IList<Language> LanguagesList = new List<Language>();
            foreach (var culture in Lang.supportedCulturesDictionary)
            {
                LanguagesList.Add(new Language { languageId = culture.Key, languageName = culture.Value.Name });
            }

            builder.Entity<Language>().HasData(LanguagesList);
            
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            // Seed DataBase With  SuperAdmin Account and Super Admin Role 
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = ApplicationRole.SuperAdmin,
                    Name = nameof(ApplicationRole.SuperAdmin),
                    NormalizedName = nameof(ApplicationRole.SuperAdmin).ToUpper(),
                    IsActive = true

                },
                new ApplicationRole
                {
                    Id = ApplicationRole.Admin,
                    Name = nameof(ApplicationRole.Admin),
                    NormalizedName = nameof(ApplicationRole.Admin).ToUpper(),
                    IsActive = true

                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 1,
                UserName = "superadmin",
                NormalizedUserName = "superadmin".ToUpper(),
                Email = "some-superadmin-email@nonce.fake",
                NormalizedEmail = "some-superadmin-email@nonce.fake".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456a@A"),
                SecurityStamp = string.Empty,
                IsDeleted=false,
                IsActive=true,
                pic= @"Uploads/Users/mostafa.jpg",
                RoleId = ApplicationRole.SuperAdmin ,// Super Admin
                BranchId=1
                

            });

            builder.Entity<IdentityUserRole<long>>().HasData(new IdentityUserRole<long>
            {
                RoleId = ApplicationRole.SuperAdmin,
                UserId = 1
            });


            //------------------------------------------------------------------------------------------------------------------------------------------------
            //Seed Pages Names and its ids 
            //------------------------------------------------------------------------------------------------------------------------------------------------

            IList<Page> PagesList = new List<Page>();

            foreach (Page.Pages page in Enum.GetValues(typeof(Page.Pages)))
            {
                PagesList.Add(
                    new Page
                    {
                        pageId = Convert.ToInt32(page),
                        pageTitle = page.ToString()
                    }
                );
            }
            builder.Entity<Page>().HasData(PagesList);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //  Seed Action and Action_Lang
            //------------------------------------------------------------------------------------------------------------------------------------------------------
            builder.Entity<Action>().HasData(

                 new Action
                 {
                     actionId = Action.Create,
                     actionName = nameof(Action.Create) // assing "Create" word

                 },
                new Action
                {
                    actionId = Action.Read, // assing  id
                    actionName = nameof(Action.Read) // assing "Read" word

                },
                new Action
                {
                    actionId = Action.Update,
                    actionName = nameof(Action.Update) // assing "Update" word

                },
                new Action
                {
                    actionId = Action.Delete,
                    actionName = nameof(Action.Delete) // assing "Delete" word

                }
            );

            builder.Entity<Action_Lang>().HasData(

                // Create

                new Action_Lang
                {
                    actionLangId = 4,
                    ActionId = Action.Create,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    actionName = "إضافة"
                },
                new Action_Lang
                {
                    actionLangId = 5,
                    ActionId = Action.Create,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    actionName = "Create"
                },
                new Action_Lang
                {
                    actionLangId = 6,
                    ActionId = Action.Create,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    actionName = "ajouter"
                },

                // Read

                new Action_Lang
                {
                    actionLangId=1,
                    ActionId = Action.Read,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    actionName = "قراءة"
                },
                new Action_Lang
                {
                    actionLangId = 2,
                    ActionId = Action.Read,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    actionName = "Reading"
                },
                new Action_Lang
                {
                    actionLangId = 3,
                    ActionId = Action.Read,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    actionName = "en train de lire"
                },

                // Update

                new Action_Lang
                {
                    actionLangId = 7,
                    ActionId = Action.Update,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    actionName = "تعديل"
                },
                new Action_Lang
                {
                    actionLangId = 8,
                    ActionId = Action.Update,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    actionName = "Update"
                },
                new Action_Lang
                {
                    actionLangId = 9,
                    ActionId = Action.Update,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    actionName = "Mettre à jour"
                },

                // Delete

                new Action_Lang
                {
                    actionLangId = 10,
                    ActionId = Action.Delete,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    actionName = "حذف"
                },
                new Action_Lang
                {
                    actionLangId = 11,
                    ActionId = Action.Delete,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    actionName = "Delete"
                },
                new Action_Lang
                {
                    actionLangId = 12,
                    ActionId = Action.Delete,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    actionName = "Supprimer"
                }

            );
            

            //---------------------------------------------------------------------------------------------------
            // Seed Buy_State Data and Buy_State_Lang
            //---------------------------------------------------------------------------------------------------
            builder.Entity<Buy_State>().HasData(
                new Buy_State
                {
                    buyStateId = Buy_State.New,
                    stateName = nameof(Buy_State.New),
                    icon = "icon-stack-text",
                    cssClass = "label-success",

                },
                new Buy_State
                {
                    buyStateId = Buy_State.Deleted,
                    stateName = nameof(Buy_State.Deleted),
                    icon = "icon-trash",
                    cssClass = "label-danger",

                },
                new Buy_State
                {
                    buyStateId = Buy_State.Refunded,
                    stateName = nameof(Buy_State.Refunded),
                    icon = "icon-rotate-cw2",
                    cssClass = "label-warning",

                },
                new Buy_State
                {
                    buyStateId = Buy_State.Initial,
                    stateName = nameof(Buy_State.Initial),
                    icon = "icon-lock2",
                    cssClass = "label-default",

                }
            );

            builder.Entity<Buy_State_Lang>().HasData(

                // New

                new Buy_State_Lang
                {
                    buyStateLangId=1,
                    Buy_StateId = Buy_State.New,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    stateName = "جديد"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 2,
                    Buy_StateId = Buy_State.New,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "New"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 3,
                    Buy_StateId = Buy_State.New,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "Nouveau"
                },

                // Deleted

                new Buy_State_Lang
                {
                    buyStateLangId = 4,
                    Buy_StateId = Buy_State.Deleted,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    stateName = "تم الحذف"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 5,
                    Buy_StateId = Buy_State.Deleted,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "Deleted"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 6,
                    Buy_StateId = Buy_State.Deleted,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "Suppression terminée"
                },

                // Refunded

                new Buy_State_Lang
                {
                    buyStateLangId = 7,
                    Buy_StateId = Buy_State.Refunded,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    stateName = "فاتورة مرتجع"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 8,
                    Buy_StateId = Buy_State.Refunded,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "Refunded Invoice"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 9,
                    Buy_StateId = Buy_State.Refunded,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "Facture remboursée"
                },

                // Initial

                new Buy_State_Lang
                {
                    buyStateLangId = 10,
                    Buy_StateId = Buy_State.Initial,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    stateName = "بداية"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 11,
                    Buy_StateId = Buy_State.Initial,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "initial"
                },
                new Buy_State_Lang
                {
                    buyStateLangId = 12,
                    Buy_StateId = Buy_State.Initial,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "initiale"
                }

            );

            //-----------------------------------------------------------------------------------------------------------------
            // Seed Sell_state Data and Sell_State_Lang
            //-----------------------------------------------------------------------------------------------------------------

            builder.Entity<Sell_State>().HasData(
                new Sell_State
                {
                    sellStateId = Sell_State.New,
                    stateName = nameof(Sell_State.New),
                    icon = "icon-stack-text",
                    cssClass = "label-success",

                },
                new Sell_State
                {
                    sellStateId = Sell_State.Deleted,
                    stateName = nameof(Sell_State.Deleted),
                    icon = "icon-trash",
                    cssClass = "label-danger",

                },
                new Sell_State
                {
                    sellStateId = Sell_State.Refunded,
                    stateName = nameof(Sell_State.Refunded),
                    icon = "icon-rotate-cw2",
                    cssClass = "label-warning",

                }

            );

            builder.Entity<Sell_State_Lang>().HasData(

                // New

                new Sell_State_Lang
                {
                    sellStateLangId=1,
                    Sell_StateId = Sell_State.New,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    stateName = "جديد"
                },
                new Sell_State_Lang
                {
                    sellStateLangId = 2,
                    Sell_StateId = Sell_State.New,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "New"
                },
                new Sell_State_Lang
                {
                    sellStateLangId = 3,
                    Sell_StateId = Sell_State.New,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "Nouveau"
                },

                // Deleted

                new Sell_State_Lang
                {
                    sellStateLangId = 4,
                    Sell_StateId = Sell_State.Deleted,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    stateName = "تم الحذف"
                },
                new Sell_State_Lang
                {
                    sellStateLangId = 5,
                    Sell_StateId = Sell_State.Deleted,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "Deleted"
                },
                new Sell_State_Lang
                {
                    sellStateLangId = 6,
                    Sell_StateId = Sell_State.Deleted,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "Suppression terminée"
                },

                 // Refunded

                 new Sell_State_Lang
                 {
                     sellStateLangId = 7,
                     Sell_StateId = Sell_State.Refunded,
                     LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                     stateName = "فاتورة مرتجع"
                 },
                new Sell_State_Lang
                {
                    sellStateLangId = 8,
                    Sell_StateId = Sell_State.Refunded,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    stateName = "Invoice Refunded"
                },
                new Sell_State_Lang
                {
                    sellStateLangId = 9,
                    Sell_StateId = Sell_State.Refunded,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    stateName = "Facture remboursée"
                }

            );

            //-----------------------------------------------------------------------------------------------------------------
            // Seed Titel and Titel_Lang with Male,Female
            //-----------------------------------------------------------------------------------------------------------------
            builder.Entity<Title>().HasData(
                new Title {
                    titleId =Title.Male ,
                    title =nameof(Title.Male)
                },
                new Title
                {
                    titleId = Title.Female,
                    title = nameof(Title.Female)
                }
                );

            builder.Entity<Title_Lang>().HasData(
                
                // Male

                new Title_Lang
                {
                    titleLangId=1,
                    TitleId = Title.Male,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    title = "ذكر"
                },
                new Title_Lang
                {
                    titleLangId = 2,
                    TitleId = Title.Male,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    title = "Male"
                },
                new Title_Lang
                {
                    titleLangId = 3,
                    TitleId = Title.Male,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    title = "mâle"
                },

                // Female

                new Title_Lang
                {
                    titleLangId = 4,
                    TitleId = Title.Female,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                    title = "أنثى"
                },
                new Title_Lang
                {
                    titleLangId = 5,
                    TitleId = Title.Female,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                    title = "Female"
                },
                new Title_Lang
                {
                    titleLangId = 6,
                    TitleId = Title.Female,
                    LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                    title = "femelle"
                }
                );
            
            //-----------------------------------------------------------------------------------------------------------------
            // Seed Payment_Method and Payment_Method_Lang with "Cash" Value 
            //-----------------------------------------------------------------------------------------------------------------
            builder.Entity<Payment_Method>().HasData(

                new Payment_Method
                {
                    paymentMethodId=1,
                    paymentMethod="Cash",
                    icon= "icon-stack-text",
                    cssClass= "label-primary"
                }

                );

            builder.Entity<Payment_Method_Lang>().HasData(

               new Payment_Method_Lang
               {
                   paymentMethodLangId=1,
                   Payment_MethodId=1,//Cash
                   LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.Arabic).Key,
                   paymentMethod = "كاش"
                   
               },

               new Payment_Method_Lang
               {
                   paymentMethodLangId = 2,
                   Payment_MethodId = 1,//Cash
                   LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.English_UK).Key,
                   paymentMethod = "Cash",
                   
               },
               new Payment_Method_Lang
               {
                   paymentMethodLangId = 3,
                   Payment_MethodId = 1,//Cash
                   LanguageId = Lang.supportedCulturesDictionary.Single(culture => culture.Value.Name == Lang.French).Key,
                   paymentMethod = "en espèces",
                   
               }
               );

            //-----------------------------------------------------------------------------------------------------------------
            // Seed Tax and Discount Defualt Value is 0%
            //-----------------------------------------------------------------------------------------------------------------

            builder.Entity<Tax>().HasData(
                new Tax
                {
                    taxId = 1,
                    isDeleted = false,
                    isPercent = true,
                    taxValue = 0,
                    title = "0%"
                }
                );

            builder.Entity<Discount>().HasData(
                new Discount
                {
                    discountId = 1,
                    isDeleted = false,
                    isPercent = true,
                    discountValue = 0,
                    title = "0%"
                }
                );

        }


    }
}
