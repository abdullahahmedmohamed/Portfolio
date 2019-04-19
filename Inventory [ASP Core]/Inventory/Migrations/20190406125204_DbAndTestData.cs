using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class DbAndTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    actionId = table.Column<int>(nullable: false),
                    actionName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.actionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    brandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    companyName = table.Column<string>(maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brandId);
                });

            migrationBuilder.CreateTable(
                name: "Buy_States",
                columns: table => new
                {
                    buyStateId = table.Column<int>(nullable: false),
                    stateName = table.Column<string>(maxLength: 15, nullable: true),
                    icon = table.Column<string>(maxLength: 50, nullable: true),
                    cssClass = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy_States", x => x.buyStateId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    categoryName = table.Column<string>(maxLength: 50, nullable: true),
                    discription = table.Column<string>(maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    discountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    discountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    isPercent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.discountId);
                });

            migrationBuilder.CreateTable(
                name: "Expenses_Types",
                columns: table => new
                {
                    expensesTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(maxLength: 60, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses_Types", x => x.expensesTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    languageId = table.Column<int>(nullable: false),
                    languageName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.languageId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    orgId = table.Column<int>(nullable: false),
                    orgName = table.Column<string>(maxLength: 50, nullable: true),
                    website = table.Column<string>(maxLength: 150, nullable: true),
                    mainEmail = table.Column<string>(maxLength: 100, nullable: true),
                    logo = table.Column<string>(maxLength: 260, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.orgId);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    pageId = table.Column<int>(nullable: false),
                    pageTitle = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.pageId);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Methods",
                columns: table => new
                {
                    paymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    paymentMethod = table.Column<string>(maxLength: 50, nullable: true),
                    icon = table.Column<string>(maxLength: 50, nullable: true),
                    cssClass = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Methods", x => x.paymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Sell_States",
                columns: table => new
                {
                    sellStateId = table.Column<int>(nullable: false),
                    stateName = table.Column<string>(maxLength: 15, nullable: true),
                    icon = table.Column<string>(maxLength: 50, nullable: true),
                    cssClass = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell_States", x => x.sellStateId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    supplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    supplierName = table.Column<string>(maxLength: 50, nullable: true),
                    pic = table.Column<string>(maxLength: 260, nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 11, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    fax = table.Column<string>(maxLength: 11, nullable: true),
                    website = table.Column<string>(maxLength: 50, nullable: true),
                    companyName = table.Column<string>(maxLength: 50, nullable: true),
                    openAccount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.supplierId);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    taxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    taxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    isPercent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.taxId);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    titleId = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 10, nullable: true),
                    icon = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.titleId);
                });

            migrationBuilder.CreateTable(
                name: "Trans_Types",
                columns: table => new
                {
                    transTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transType = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_Types", x => x.transTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productName = table.Column<string>(maxLength: 50, nullable: true),
                    discription = table.Column<string>(maxLength: 250, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pic = table.Column<string>(maxLength: 260, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    code = table.Column<string>(maxLength: 25, nullable: true),
                    barcode = table.Column<string>(maxLength: 25, nullable: true),
                    pic2 = table.Column<string>(maxLength: 260, nullable: true),
                    pic3 = table.Column<string>(maxLength: 260, nullable: true),
                    pic4 = table.Column<string>(maxLength: 260, nullable: true),
                    expiryDate = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "brandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action_Lang",
                columns: table => new
                {
                    actionLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    discription = table.Column<string>(maxLength: 250, nullable: true),
                    actionName = table.Column<string>(maxLength: 20, nullable: true),
                    ActionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action_Lang", x => x.actionLangId);
                    table.ForeignKey(
                        name: "FK_Action_Lang_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "actionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_Lang_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buy_State_Langs",
                columns: table => new
                {
                    buyStateLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    stateName = table.Column<string>(maxLength: 60, nullable: true),
                    Buy_StateId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy_State_Langs", x => x.buyStateLangId);
                    table.ForeignKey(
                        name: "FK_Buy_State_Langs_Buy_States_Buy_StateId",
                        column: x => x.Buy_StateId,
                        principalTable: "Buy_States",
                        principalColumn: "buyStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buy_State_Langs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    branchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    branchName = table.Column<string>(maxLength: 50, nullable: true),
                    address = table.Column<string>(maxLength: 250, nullable: true),
                    mobiles = table.Column<string>(maxLength: 11, nullable: true),
                    phones = table.Column<string>(maxLength: 11, nullable: true),
                    faxs = table.Column<string>(maxLength: 11, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    openDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.branchId);
                    table.ForeignKey(
                        name: "FK_Branches_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "orgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Page_Lang",
                columns: table => new
                {
                    pageLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pageTitle = table.Column<string>(maxLength: 50, nullable: true),
                    discription = table.Column<string>(maxLength: 250, nullable: true),
                    PageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page_Lang", x => x.pageLangId);
                    table.ForeignKey(
                        name: "FK_Page_Lang_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Page_Lang_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "pageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_Action",
                columns: table => new
                {
                    roleActionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isAllow = table.Column<bool>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    ActionId = table.Column<int>(nullable: false),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Action", x => x.roleActionId);
                    table.ForeignKey(
                        name: "FK_Role_Action_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "actionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Action_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "pageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Action_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Method_Langs",
                columns: table => new
                {
                    paymentMethodLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    paymentMethod = table.Column<string>(maxLength: 50, nullable: true),
                    Payment_MethodId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Method_Langs", x => x.paymentMethodLangId);
                    table.ForeignKey(
                        name: "FK_Payment_Method_Langs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Method_Langs_Payment_Methods_Payment_MethodId",
                        column: x => x.Payment_MethodId,
                        principalTable: "Payment_Methods",
                        principalColumn: "paymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sell_State_Langs",
                columns: table => new
                {
                    sellStateLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    stateName = table.Column<string>(maxLength: 50, nullable: true),
                    Sell_StateId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell_State_Langs", x => x.sellStateLangId);
                    table.ForeignKey(
                        name: "FK_Sell_State_Langs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sell_State_Langs_Sell_States_Sell_StateId",
                        column: x => x.Sell_StateId,
                        principalTable: "Sell_States",
                        principalColumn: "sellStateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier_Payments",
                columns: table => new
                {
                    supplierPaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    paymentDate = table.Column<DateTime>(nullable: false),
                    paymentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    Payment_MethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_Payments", x => x.supplierPaymentId);
                    table.ForeignKey(
                        name: "FK_Supplier_Payments_Payment_Methods_Payment_MethodId",
                        column: x => x.Payment_MethodId,
                        principalTable: "Payment_Methods",
                        principalColumn: "paymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_Payments_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "supplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    customerName = table.Column<string>(maxLength: 50, nullable: true),
                    pic = table.Column<string>(maxLength: 260, nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    idNo = table.Column<string>(maxLength: 14, nullable: true),
                    address = table.Column<string>(maxLength: 250, nullable: true),
                    phone = table.Column<string>(maxLength: 11, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    fax = table.Column<string>(maxLength: 11, nullable: true),
                    companyName = table.Column<string>(maxLength: 50, nullable: true),
                    openAccount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    TitleId = table.Column<int>(nullable: false),
                    DiscountId = table.Column<int>(nullable: false),
                    TaxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_Customers_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "discountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "taxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "titleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Title_Langs",
                columns: table => new
                {
                    titleLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleId = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 20, nullable: true),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title_Langs", x => x.titleLangId);
                    table.ForeignKey(
                        name: "FK_Title_Langs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Title_Langs_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "titleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trans_Type_Langs",
                columns: table => new
                {
                    transTypeLangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transType = table.Column<string>(maxLength: 50, nullable: true),
                    Trans_TypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_Type_Langs", x => x.transTypeLangId);
                    table.ForeignKey(
                        name: "FK_Trans_Type_Langs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "languageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trans_Type_Langs_Trans_Types_Trans_TypeId",
                        column: x => x.Trans_TypeId,
                        principalTable: "Trans_Types",
                        principalColumn: "transTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    idNo = table.Column<string>(maxLength: 14, nullable: true),
                    pic = table.Column<string>(maxLength: 260, nullable: true),
                    joinDate = table.Column<DateTime>(nullable: false),
                    birthDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    expensesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    expensesDate = table.Column<DateTime>(nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    Expenses_TypeId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.expensesId);
                    table.ForeignKey(
                        name: "FK_Expenses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Expenses_Types_Expenses_TypeId",
                        column: x => x.Expenses_TypeId,
                        principalTable: "Expenses_Types",
                        principalColumn: "expensesTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    locationname = table.Column<string>(maxLength: 50, nullable: true),
                    discription = table.Column<string>(maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locationId);
                    table.ForeignKey(
                        name: "FK_Locations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Safe",
                columns: table => new
                {
                    safeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    safeName = table.Column<string>(maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safe", x => x.safeId);
                    table.ForeignKey(
                        name: "FK_Safe_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Payments",
                columns: table => new
                {
                    customerPaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    paymentDate = table.Column<DateTime>(nullable: false),
                    paymentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Payment_MethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Payments", x => x.customerPaymentId);
                    table.ForeignKey(
                        name: "FK_Customer_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Payments_Payment_Methods_Payment_MethodId",
                        column: x => x.Payment_MethodId,
                        principalTable: "Payment_Methods",
                        principalColumn: "paymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrials",
                columns: table => new
                {
                    auditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actionDate = table.Column<DateTime>(nullable: false),
                    recordId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrials", x => x.auditId);
                    table.ForeignKey(
                        name: "FK_AuditTrials_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "actionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditTrials_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "pageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditTrials_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBranches",
                columns: table => new
                {
                    UserBranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranches", x => x.UserBranchId);
                    table.ForeignKey(
                        name: "FK_UserBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBranches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    buyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    buyDate = table.Column<DateTime>(nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    supplierCode = table.Column<string>(maxLength: 50, nullable: true),
                    docment = table.Column<string>(maxLength: 260, nullable: true),
                    isPercentTax = table.Column<bool>(nullable: false),
                    isPercentDiscount = table.Column<bool>(nullable: false),
                    isReturn = table.Column<bool>(nullable: false),
                    isAgel = table.Column<bool>(nullable: false),
                    Buy_StateId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.buyId);
                    table.ForeignKey(
                        name: "FK_Buy_Buy_States_Buy_StateId",
                        column: x => x.Buy_StateId,
                        principalTable: "Buy_States",
                        principalColumn: "buyStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buy_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buy_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "supplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location_Qty",
                columns: table => new
                {
                    locationQtyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_Qty", x => x.locationQtyId);
                    table.ForeignKey(
                        name: "FK_Location_Qty_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_Qty_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    sellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sellDate = table.Column<DateTime>(nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    docment = table.Column<string>(maxLength: 260, nullable: true),
                    isPercentDiscount = table.Column<bool>(nullable: false),
                    isPercentTax = table.Column<bool>(nullable: false),
                    isReturn = table.Column<bool>(nullable: false),
                    isAgel = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Sell_StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => x.sellId);
                    table.ForeignKey(
                        name: "FK_Sells_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Sell_States_Sell_StateId",
                        column: x => x.Sell_StateId,
                        principalTable: "Sell_States",
                        principalColumn: "sellStateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taswya",
                columns: table => new
                {
                    taswyaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    taswyaDate = table.Column<DateTime>(nullable: false),
                    discription = table.Column<string>(maxLength: 250, nullable: true),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taswya", x => x.taswyaId);
                    table.ForeignKey(
                        name: "FK_Taswya_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taswya_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    transferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transferDate = table.Column<DateTime>(nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fromLocation = table.Column<int>(nullable: false),
                    toLocation = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    LocationFromlocationId = table.Column<int>(nullable: true),
                    LocationTolocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.transferId);
                    table.ForeignKey(
                        name: "FK_Transfer_Locations_LocationFromlocationId",
                        column: x => x.LocationFromlocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfer_Locations_LocationTolocationId",
                        column: x => x.LocationTolocationId,
                        principalTable: "Locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Safe_Trans",
                columns: table => new
                {
                    safeTransId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    transDate = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    comment = table.Column<string>(maxLength: 250, nullable: true),
                    SafeId = table.Column<int>(nullable: false),
                    Trans_TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safe_Trans", x => x.safeTransId);
                    table.ForeignKey(
                        name: "FK_Safe_Trans_Safe_SafeId",
                        column: x => x.SafeId,
                        principalTable: "Safe",
                        principalColumn: "safeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Safe_Trans_Trans_Types_Trans_TypeId",
                        column: x => x.Trans_TypeId,
                        principalTable: "Trans_Types",
                        principalColumn: "transTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buy_Details",
                columns: table => new
                {
                    buyDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPercentDiscount = table.Column<bool>(nullable: false),
                    BuyId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy_Details", x => x.buyDetailsId);
                    table.ForeignKey(
                        name: "FK_Buy_Details_Buy_BuyId",
                        column: x => x.BuyId,
                        principalTable: "Buy",
                        principalColumn: "buyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buy_Details_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sell_Details",
                columns: table => new
                {
                    sellDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellId = table.Column<int>(nullable: false),
                    isPercentDiscount = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell_Details", x => x.sellDetailsId);
                    table.ForeignKey(
                        name: "FK_Sell_Details_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sell_Details_Sells_SellId",
                        column: x => x.SellId,
                        principalTable: "Sells",
                        principalColumn: "sellId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer_Details",
                columns: table => new
                {
                    transferDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer_Details", x => x.transferDetailsId);
                    table.ForeignKey(
                        name: "FK_Transfer_Details_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfer_Details_Transfer_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfer",
                        principalColumn: "transferId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "actionId", "actionName" },
                values: new object[,]
                {
                    { 1, "Create" },
                    { 2, "Read" },
                    { 3, "Update" },
                    { 4, "Delete" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "IsActive", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "f2f03ae7-89b3-46d6-b888-074afc67f7b1", null, true, false, "SuperAdmin", "SUPERADMIN" },
                    { 2L, "e9e7acf4-8e50-47c6-b543-6f724b510b38", null, true, false, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Buy_States",
                columns: new[] { "buyStateId", "cssClass", "icon", "stateName" },
                values: new object[,]
                {
                    { 1, "label-success", "icon-stack-text", "New" },
                    { 2, "label-danger", "icon-trash", "Deleted" },
                    { 3, "label-warning", "icon-rotate-cw2", "Refunded" },
                    { 4, "label-default", "icon-lock2", "Initial" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "discountId", "discountValue", "isDeleted", "isPercent", "title" },
                values: new object[] { 1, 0m, false, true, "0%" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "languageId", "languageName" },
                values: new object[,]
                {
                    { 1, "ar" },
                    { 2, "en-GB" },
                    { 3, "fr" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "orgId", "logo", "mainEmail", "orgName", "website" },
                values: new object[] { 1, "/assets/images/shop.png", "Organization@Organization.org", "Organization", "https://www.Organization.org" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "pageId", "pageTitle" },
                values: new object[,]
                {
                    { 12, "taswya" },
                    { 11, "settings" },
                    { 10, "expenses" },
                    { 9, "safe" },
                    { 8, "transfers" },
                    { 7, "buy" },
                    { 2, "account" },
                    { 5, "suppliers" },
                    { 4, "products" },
                    { 3, "customers" },
                    { 1, "home" },
                    { 6, "sell" }
                });

            migrationBuilder.InsertData(
                table: "Payment_Methods",
                columns: new[] { "paymentMethodId", "cssClass", "icon", "paymentMethod" },
                values: new object[] { 1, "label-primary", "icon-stack-text", "Cash" });

            migrationBuilder.InsertData(
                table: "Sell_States",
                columns: new[] { "sellStateId", "cssClass", "icon", "stateName" },
                values: new object[,]
                {
                    { 1, "label-success", "icon-stack-text", "New" },
                    { 2, "label-danger", "icon-trash", "Deleted" },
                    { 3, "label-warning", "icon-rotate-cw2", "Refunded" }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "taxId", "isDeleted", "isPercent", "taxValue", "title" },
                values: new object[] { 1, false, true, 0m, "0%" });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "titleId", "icon", "title" },
                values: new object[,]
                {
                    { 1, null, "Male" },
                    { 2, null, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Action_Lang",
                columns: new[] { "actionLangId", "ActionId", "LanguageId", "actionName", "discription" },
                values: new object[,]
                {
                    { 4, 1, 1, "إضافة", null },
                    { 1, 2, 1, "قراءة", null },
                    { 7, 3, 1, "تعديل", null },
                    { 10, 4, 1, "حذف", null },
                    { 5, 1, 2, "Create", null },
                    { 2, 2, 2, "Reading", null },
                    { 8, 3, 2, "Update", null },
                    { 11, 4, 2, "Delete", null },
                    { 12, 4, 3, "Supprimer", null },
                    { 9, 3, 3, "Mettre à jour", null },
                    { 3, 2, 3, "en train de lire", null },
                    { 6, 1, 3, "ajouter", null }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "branchId", "OrganizationId", "address", "branchName", "email", "faxs", "isActive", "isDeleted", "mobiles", "openDate", "phones" },
                values: new object[] { 1, 1, null, "MainBranch", null, null, true, false, null, new DateTime(2019, 4, 6, 14, 52, 3, 431, DateTimeKind.Local).AddTicks(3960), null });

            migrationBuilder.InsertData(
                table: "Buy_State_Langs",
                columns: new[] { "buyStateLangId", "Buy_StateId", "LanguageId", "stateName" },
                values: new object[,]
                {
                    { 12, 4, 3, "initiale" },
                    { 9, 3, 3, "Facture remboursée" },
                    { 3, 1, 3, "Nouveau" },
                    { 6, 2, 3, "Suppression terminée" },
                    { 8, 3, 2, "Refunded Invoice" },
                    { 5, 2, 2, "Deleted" },
                    { 2, 1, 2, "New" },
                    { 10, 4, 1, "بداية" },
                    { 7, 3, 1, "فاتورة مرتجع" },
                    { 4, 2, 1, "تم الحذف" },
                    { 1, 1, 1, "جديد" },
                    { 11, 4, 2, "initial" }
                });

            migrationBuilder.InsertData(
                table: "Payment_Method_Langs",
                columns: new[] { "paymentMethodLangId", "LanguageId", "Payment_MethodId", "paymentMethod" },
                values: new object[,]
                {
                    { 1, 1, 1, "كاش" },
                    { 2, 2, 1, "Cash" },
                    { 3, 3, 1, "en espèces" }
                });

            migrationBuilder.InsertData(
                table: "Sell_State_Langs",
                columns: new[] { "sellStateLangId", "LanguageId", "Sell_StateId", "stateName" },
                values: new object[,]
                {
                    { 9, 3, 3, "Facture remboursée" },
                    { 8, 2, 3, "Invoice Refunded" },
                    { 7, 1, 3, "فاتورة مرتجع" },
                    { 6, 3, 2, "Suppression terminée" },
                    { 2, 2, 1, "New" },
                    { 4, 1, 2, "تم الحذف" },
                    { 3, 3, 1, "Nouveau" },
                    { 1, 1, 1, "جديد" },
                    { 5, 2, 2, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "Title_Langs",
                columns: new[] { "titleLangId", "LanguageId", "TitleId", "title" },
                values: new object[,]
                {
                    { 5, 2, 2, "Female" },
                    { 1, 1, 1, "ذكر" },
                    { 2, 2, 1, "Male" },
                    { 3, 3, 1, "mâle" },
                    { 4, 1, 2, "أنثى" },
                    { 6, 3, 2, "femelle" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BranchId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName", "birthDate", "fullName", "idNo", "joinDate", "pic" },
                values: new object[] { 1L, 0, 1, "9178dd59-2a12-409c-8db6-fe1a1059de0b", "some-superadmin-email@nonce.fake", true, true, false, false, null, "SOME-SUPERADMIN-EMAIL@NONCE.FAKE", "SUPERADMIN", "AQAAAAEAACcQAAAAEHj68O32GAi7fWRtJU75WE8x1w0xSWWPc5a4v3JCQUj27MTpsTfty+1UA5yThYRGdQ==", null, false, 1L, "", false, "superadmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uploads/Users/mostafa.jpg" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "locationId", "BranchId", "discription", "isDeleted", "locationname" },
                values: new object[] { 1, 1, null, false, "MainBranch-A" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Action_Lang_ActionId",
                table: "Action_Lang",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_Lang_LanguageId",
                table: "Action_Lang",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrials_ActionId",
                table: "AuditTrials",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrials_PageId",
                table: "AuditTrials",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrials_UserId",
                table: "AuditTrials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_OrganizationId",
                table: "Branches",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_Buy_StateId",
                table: "Buy",
                column: "Buy_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_LocationId",
                table: "Buy",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_SupplierId",
                table: "Buy",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_Details_BuyId",
                table: "Buy_Details",
                column: "BuyId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_Details_ProductId",
                table: "Buy_Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_State_Langs_Buy_StateId",
                table: "Buy_State_Langs",
                column: "Buy_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_State_Langs_LanguageId",
                table: "Buy_State_Langs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Payments_CustomerId",
                table: "Customer_Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Payments_Payment_MethodId",
                table: "Customer_Payments",
                column: "Payment_MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DiscountId",
                table: "Customers",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TaxId",
                table: "Customers",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TitleId",
                table: "Customers",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_customerName_isDeleted_isActive",
                table: "Customers",
                columns: new[] { "customerName", "isDeleted", "isActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BranchId",
                table: "Expenses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Expenses_TypeId",
                table: "Expenses",
                column: "Expenses_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Qty_LocationId",
                table: "Location_Qty",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Qty_ProductId_LocationId_qty",
                table: "Location_Qty",
                columns: new[] { "ProductId", "LocationId", "qty" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BranchId",
                table: "Locations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_Lang_LanguageId",
                table: "Page_Lang",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_Lang_PageId",
                table: "Page_Lang",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Method_Langs_LanguageId",
                table: "Payment_Method_Langs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Method_Langs_Payment_MethodId",
                table: "Payment_Method_Langs",
                column: "Payment_MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productName_BrandId_isDeleted_isActive_barcode_code",
                table: "Products",
                columns: new[] { "productName", "BrandId", "isDeleted", "isActive", "barcode", "code" });

            migrationBuilder.CreateIndex(
                name: "IX_Role_Action_ActionId",
                table: "Role_Action",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Action_PageId",
                table: "Role_Action",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Action_RoleId",
                table: "Role_Action",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Safe_BranchId",
                table: "Safe",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Safe_Trans_SafeId",
                table: "Safe_Trans",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_Safe_Trans_Trans_TypeId",
                table: "Safe_Trans",
                column: "Trans_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_Details_ProductId",
                table: "Sell_Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_Details_SellId",
                table: "Sell_Details",
                column: "SellId");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_State_Langs_LanguageId",
                table: "Sell_State_Langs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_State_Langs_Sell_StateId",
                table: "Sell_State_Langs",
                column: "Sell_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_CustomerId",
                table: "Sells",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_LocationId",
                table: "Sells",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_Sell_StateId",
                table: "Sells",
                column: "Sell_StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Payments_Payment_MethodId",
                table: "Supplier_Payments",
                column: "Payment_MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Payments_SupplierId",
                table: "Supplier_Payments",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_supplierName_isDeleted_isActive",
                table: "Suppliers",
                columns: new[] { "supplierName", "isDeleted", "isActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Taswya_LocationId",
                table: "Taswya",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Taswya_ProductId",
                table: "Taswya",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_Langs_LanguageId",
                table: "Title_Langs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_Langs_TitleId",
                table: "Title_Langs",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Type_Langs_LanguageId",
                table: "Trans_Type_Langs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Type_Langs_Trans_TypeId",
                table: "Trans_Type_Langs",
                column: "Trans_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_LocationFromlocationId",
                table: "Transfer",
                column: "LocationFromlocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_LocationTolocationId",
                table: "Transfer",
                column: "LocationTolocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_Details_ProductId",
                table: "Transfer_Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_Details_TransferId",
                table: "Transfer_Details",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_BranchId",
                table: "UserBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranches_UserId",
                table: "UserBranches",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action_Lang");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditTrials");

            migrationBuilder.DropTable(
                name: "Buy_Details");

            migrationBuilder.DropTable(
                name: "Buy_State_Langs");

            migrationBuilder.DropTable(
                name: "Customer_Payments");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Location_Qty");

            migrationBuilder.DropTable(
                name: "Page_Lang");

            migrationBuilder.DropTable(
                name: "Payment_Method_Langs");

            migrationBuilder.DropTable(
                name: "Role_Action");

            migrationBuilder.DropTable(
                name: "Safe_Trans");

            migrationBuilder.DropTable(
                name: "Sell_Details");

            migrationBuilder.DropTable(
                name: "Sell_State_Langs");

            migrationBuilder.DropTable(
                name: "Supplier_Payments");

            migrationBuilder.DropTable(
                name: "Taswya");

            migrationBuilder.DropTable(
                name: "Title_Langs");

            migrationBuilder.DropTable(
                name: "Trans_Type_Langs");

            migrationBuilder.DropTable(
                name: "Transfer_Details");

            migrationBuilder.DropTable(
                name: "UserBranches");

            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.DropTable(
                name: "Expenses_Types");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Safe");

            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.DropTable(
                name: "Payment_Methods");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Trans_Types");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Buy_States");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sell_States");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
