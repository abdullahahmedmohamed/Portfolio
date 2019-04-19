using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using Inventory.ViewModels;
using Microsoft.EntityFrameworkCore;
using Inventory.DTOs;
using AutoMapper;
using Inventory.GenericClasses.ManagingFiles;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Inventory.AccountTooles;
using Microsoft.AspNetCore.Localization;
using Inventory.GenericClasses;
using Inventory.AccountTooles.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using ElmahCore;

namespace Inventory.Controllers
{
    [Authorize]
    public class SellController : Controller
    {
        private AppDbContext db;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStringLocalizer<SellController> localizer;

        public SellController(AppDbContext _db, IMapper _mapper, IHostingEnvironment _hostingEnvironment, IStringLocalizer<SellController> _localizer)
        {
            db = _db;
            mapper = _mapper;
            hostingEnvironment = _hostingEnvironment;
            localizer = _localizer;

        }

        // GET
        [TypeFilter(typeof(HasPermissionTo),
            Arguments = new object[] { Models.Action.Read })]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [TypeFilter(typeof(HasPermissionTo),
            Arguments = new object[] { Models.Action.Read })]
        public async Task<IActionResult> get(string limit, string offset, string sort, string order, string search)
        {
            //----------------------------------------------------------
            // Modefy This Select Query (Dont Use AsEnumerable)
            //----------------------------------------------------------

            int limits = 10;
            int offsets = 0;

            if (limit != "")
                limits = int.Parse(limit);
            if (offset != "")
                offsets = int.Parse(offset);

            int UserBranchId = Convert.ToInt32(User.FindFirst(ClaimName.BranchId).Value);
            int UserLangID = Lang.geUsertLangID(Request);
            // all data

            var data = db.Sells.Where(g => g.Location.BranchId == UserBranchId)
                .Select(e => new
                {

                    e.sellId,
                    e.sellDate,
                    e.Customer.customerName,
                    e.Customer.pic,
                    e.Location.locationname,
                    e.totalPrice,
                    e.totalQty,
                    e.discount,
                    e.tax,
                    e.Sell_State.cssClass,
                    e.Sell_State.icon,
                    e.Sell_State.Sell_State_Lang.Where(a => a.LanguageId == UserLangID).FirstOrDefault().stateName,


                })
                 .AsNoTracking();


            //search
            if (!string.IsNullOrEmpty(search))
            {

                if (search.Contains("#"))
                {
                    string ID = search.Remove(0, 1);
                    int IDD = 0;
                    bool isINT = int.TryParse(ID, out IDD);
                    if (isINT)
                    {
                        data = data.Where(f => f.sellId == IDD);
                    }

                }
                else
                {
                    data = data.Where(f => f.customerName.ToLower().Contains(search.ToLower()) || f.locationname.ToLower().Contains(search.ToLower()));
                }
            }

            // Total Rows Count Before Skip and Take
            var total = data.Count();

            // sort and paging
            if (sort != null)
            {
                if (sort == "sellId" && order == "asc")
                    data = data.OrderBy(f => f.sellId).Skip(offsets).Take(limits);
                else if (sort == "sellId" && order == "desc")
                    data = data.OrderByDescending(f => f.sellId).Skip(offsets).Take(limits);
                else if (sort == "customerName" && order == "asc")
                    data = data.OrderBy(f => f.customerName).Skip(offsets).Take(limits);
                else if (sort == "customerName" && order == "desc")
                    data = data.OrderByDescending(f => f.customerName).Skip(offsets).Take(limits);
                else if (sort == "sellDate" && order == "asc")
                    data = data.OrderBy(f => f.sellDate).Skip(offsets).Take(limits);
                else if (sort == "sellDate" && order == "desc")
                    data = data.OrderByDescending(f => f.sellDate).Skip(offsets).Take(limits);
                else if (sort == "locationname" && order == "asc")
                    data = data.OrderBy(f => f.locationname).Skip(offsets).Take(limits);
                else if (sort == "locationname" && order == "desc")
                    data = data.OrderByDescending(f => f.locationname).Skip(offsets).Take(limits);
                else if (sort == "discount" && order == "asc")
                    data = data.OrderBy(f => f.discount).Skip(offsets).Take(limits);
                else if (sort == "discount" && order == "desc")
                    data = data.OrderByDescending(f => f.discount).Skip(offsets).Take(limits);
                else if (sort == "tax" && order == "asc")
                    data = data.OrderBy(f => f.tax).Skip(offsets).Take(limits);
                else if (sort == "tax" && order == "desc")
                    data = data.OrderByDescending(f => f.tax).Skip(offsets).Take(limits);
                else if (sort == "stateName" && order == "asc")
                    data = data.OrderBy(f => f.stateName).Skip(offsets).Take(limits);
                else if (sort == "stateName" && order == "desc")
                    data = data.OrderByDescending(f => f.stateName).Skip(offsets).Take(limits);
                else if (sort == "totalPrice" && order == "asc")
                    data = data.OrderBy(f => f.totalPrice).Skip(offsets).Take(limits);
                else if (sort == "totalPrice" && order == "desc")
                    data = data.OrderByDescending(f => f.totalPrice).Skip(offsets).Take(limits);
                else if (sort == "buyCount" && order == "asc")
                    data = data.OrderBy(f => f.totalQty).Skip(offsets).Take(limits);
                else if (sort == "buyCount" && order == "desc")
                    data = data.OrderByDescending(f => f.totalQty).Skip(offsets).Take(limits);


            }
            else
            {
                //dfualt sorting and paging
                data = data.OrderByDescending(f => f.sellId).Skip(offsets).Take(limits);

            }

            var rows = await data.ToListAsync();

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Generate Permissions Object for Current Pge This Object Contains  {CanCreate,CanUpdate,CanDelete} For Logged In User and For This Controller Page
            // Note : I follow a Convention that is the PageName Equal Controller Name 
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------
            string pageName = ControllerContext.ActionDescriptor.ControllerName.ToLower();
            var userPagePermission = UserPagePermission.GetPagePermissions(User, ControllerContext.ActionDescriptor.ControllerName.ToLower());

            //--------------------------------------------------------------------------------------------------------------------------------------------------
            // Return : total= rows total count / rows = matched Records after pagination / userPagePermission object {CanCreate,CanUpdate,CanDelete}
            //--------------------------------------------------------------------------------------------------------------------------------------------------
            return Json(new { total = total, rows = rows, userPagePermission = userPagePermission });

        }

        [TypeFilter(typeof(HasPermissionTo),
            Arguments = new object[] { Models.Action.Create })]
        public IActionResult Add()
        {
            int UserBranchId = Convert.ToInt32(User.FindFirst(ClaimName.BranchId).Value);
            ViewBag.locations = db.Locations.Where(g => g.isDeleted == false && g.BranchId == UserBranchId).OrderBy(g => g.locationname);

            return View();
        }

        public IActionResult AddSellDetailsRow(string productName, string code, string barcode, int productId, decimal qty, decimal price, decimal discount, bool isPercentDiscount, int rowIndex)
        {
            var productCustomInfo = db.Products.Include(p => p.Brand).Where(p => p.productId == productId).Select(p => new { p.pic, p.Brand.companyName }).SingleOrDefault();
            var companyName = productCustomInfo.companyName;
            string pic = productCustomInfo.pic;

            decimal total = calcTotal(discount, isPercentDiscount, qty, price);

            InvoiceDetailsRow row = new InvoiceDetailsRow()
            {
                rowIndex = rowIndex,
                barcode = barcode,
                code = code,
                companyName = companyName,
                pic = pic,
                productName = productName,
                total = total.ToString("0.##"),
                Sell_DetailsDto = new Dictionary<int, Sell_DetailsDto>()
            };

            var Sell_DetailsRow = new Sell_DetailsDto()
            {
                ProductId = productId,
                qty = qty,
                unitPrice = price,
                discount = discount,
                isPercentDiscount = isPercentDiscount
            };

            row.Sell_DetailsDto.Add(row.rowIndex, Sell_DetailsRow);

            return PartialView("Row", row);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [TypeFilter(typeof(HasPermissionTo),
            Arguments = new object[] { Models.Action.Create })]
        public async Task<IActionResult> Add(SellDto sellDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    // Get All Model Errors and Join Them in One Sting Seperated by coma ","
                    var aLLmsg = Global.ModelErrorsToJoinString(ModelState, ",");
                    throw new ApplicationException(aLLmsg);
                }
               
                Sell sell = new Sell();
                // Mapping Sell Object and Sell_Details Object and Apply business requirements
                // Note maybe throw ApplicationException: in case un valid data for example : requsted quntity not available
                await PrepareSellObjectAsync(sell, sellDto);

                //--------------------------------------------------------------------------------------------------------------------------------------------
                // Upload Sell Document {Note: the file was Validated by DataAnnotation in DTO model} (Note: Uploade Operation must come after all Validation)
                //--------------------------------------------------------------------------------------------------------------------------------------------
                if (sellDto.docment != null && sellDto.docment.Length != 0)
                {
                    sell.docment = await FileManager.UploadFileAsync(sellDto.docment, hostingEnvironment.WebRootPath, FileSettings.SellDirectory);
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------
                
                using (var transaction = db.Database.BeginTransaction())
                {
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    // Insert Sell Object To DataBase
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    db.Sells.Add(sell);
                    await db.SaveChangesAsync();
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    // AuditTrial => Log Insert Operation To DataBase 
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    AuditTrial aditTrail = new AuditTrial()
                    {
                        actionDate = DateTime.UtcNow,
                        ActionId = Models.Action.Create,
                        // This will Throw Exception in case a ControllerName not Match one of Pages Enum Member
                        PageId = Convert.ToInt32(Enum.Parse(typeof(Page.Pages), ControllerContext.ActionDescriptor.ControllerName.ToLower())),
                        recordId = sell.sellId,
                        UserId = Convert.ToInt64(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value)
                    };
                    await db.AuditTrials.AddAsync(aditTrail);
                    await db.SaveChangesAsync();
                    //--------------------------------------------------------------------------------------------------------------------------------------------
                    //throw new Exception();
                    transaction.Commit();
                }


                return Json(new { isError = 0, msg = localizer["SavedSuccessfully"] });
            }
            catch (ApplicationException ex)
            {
                return Json(new
                {
                    isError = 1,
                    msg = ex.Message
                });

            }
            catch (DbUpdateException ex)
            {
                Global.LogException(HttpContext, ex);

                return Json(new
                {
                    isError = 1,
                    msg = localizer["UnableToSaveTryAgainOrCallUs"]
                });
            }
            catch (Exception ex)
            {
                Global.LogException(HttpContext, ex);
                return Json(new
                {
                    isError = 1,
                    msg = ex.Message
                });
            }

        }

        [TypeFilter(typeof(HasPermissionTo),
                    Arguments = new object[] { Models.Action.Update })]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
                return NotFound();

            int UserBranchId = Convert.ToInt32(User.FindFirst(ClaimName.BranchId).Value);

            var data = await db.Sell_Details.Include(d => d.Sell).Include(d => d.Product).Where(d => d.SellId == id && d.Sell.Location.BranchId == UserBranchId).Select(d => new
            {

                d.Sell,
                CustomerName = d.Sell.Customer.customerName,
                Details = d,
                d.Product.productName,
                d.Product.pic,
                d.Product.code,
                d.Product.barcode,
                d.Product.Brand.companyName,

            })
            .AsNoTracking()
            .ToListAsync();

            if (data == null || data.Count == 0)
                return NotFound();



            var Sell = data.FirstOrDefault().Sell;

            //************************************************************************************************************************************************************************************
            // Mapping Sell_Details To InvoiceDetailsRow Object
            //************************************************************************************************************************************************************************************
            int i = 0;
            var DetailsRows = data.Select(d => new InvoiceDetailsRow()
            {
                rowIndex = i,
                barcode = d.barcode,
                code = d.code,
                companyName = d.companyName,
                pic = d.pic,
                productName = d.productName,
                total = calcTotal(d.Details.discount, d.Details.isPercentDiscount, d.Details.qty, d.Details.unitPrice).ToString("0.##"),

                Sell_DetailsDto = new Dictionary<int, Sell_DetailsDto>()
                    {   { i++, mapper.Map<Sell_DetailsDto>(d.Details)} }
            }).ToList();

            //************************************************************************************************************************************************************************************
            //************************************************************************************************************************************************************************************



            var locations = await db.Locations.Where(g => g.isDeleted == false && g.BranchId == UserBranchId).OrderBy(g => g.locationname).ToListAsync();

            //------------------------------------------------------------------------------------------------------------------------------------------------
            // Mapping Result Set To SellEditViewModel Object
            //------------------------------------------------------------------------------------------------------------------------------------------------
            var EditViewModel = new SellEditViewModel
            {
                SellDto = mapper.Map<SellDto>(Sell),
                CustomerName = data.FirstOrDefault().CustomerName,
                Sell_DetailsDto = DetailsRows,
                Locations = locations

            };

            //------------------------------------------------------------------------------------------------------------------------------------------------

            return View(EditViewModel);
        }

        // Rest Product Quntity of specific Location For Deleted Sell Invoice
        //in Case Sell invoice state => Refunded (Returned) {Decrease Location_Qty}
        //in Case Sell invoice state => New (normal sell invoice) {Increase Location_Qty}
        private async Task ResetLocationQtyAsync(Sell sell)
        {
            // Products that will be reseted in the Qty
            var oldProductsIDs = sell.Sell_Details.Select(d => d.ProductId).Distinct().ToList();
            var locationQtys = await db.Location_Qty.Where(q => (oldProductsIDs.Contains(q.ProductId) && q.LocationId == sell.LocationId)).ToListAsync();

            // Use Sell_Details to Update Location_Qty 

            //(1 or -1) In case (+1) mean Location_Qty will Increased in amount]|[ In Case (-1) LocationQty will decreased in amount
            int minusOrPlus = (sell.isReturn) ? (-1) : (1);
            foreach (var item in sell.Sell_Details)
            {
                locationQtys.Single(q => q.ProductId == item.ProductId && q.LocationId == sell.LocationId)
                    .qty += (minusOrPlus * item.qty);// example : [20 + (1*10) = 30] and [20 + (-1*10) =10]
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [TypeFilter(typeof(HasPermissionTo),
                    Arguments = new object[] { Models.Action.Update })]
        public async Task<IActionResult> Edit(SellDto sellDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Get All Model Errors and Join Them in One Sting Seperated by coma ","
                    var aLLmsg = Global.ModelErrorsToJoinString(ModelState, ",");
                    throw new ApplicationException(aLLmsg);
                }

                int UserBranchId = Convert.ToInt32(User.FindFirst(ClaimName.BranchId).Value);

                // Get Sell&Sell_Details Obj From DB where  1- sell not deleted  2- sell belongs to user Branch
                Sell sellToUpdate = await db.Sells.Include(s => s.Sell_Details).FirstOrDefaultAsync(s => s.sellId == sellDto.sellId && s.isDeleted != true && s.Location.BranchId == UserBranchId);

                if (sellToUpdate == null)
                    return NotFound();


                await ResetLocationQtyAsync(sellToUpdate);

                // Delete Sell_Details
                db.Sell_Details.RemoveRange(sellToUpdate.Sell_Details);
                // Clear old Sell_Details from object to add New Sell_Details
                sellToUpdate.Sell_Details = null;

                // Mapping Sell Object and Sell_Details Object and Apply business requirements
                // Note maybe throw ApplicationException: in case un valid data for example : requsted quntity not available
                await PrepareSellObjectAsync(sellToUpdate, sellDto);

                //--------------------------------------------------------------------------------------------------------------------------------------------
                // Upload Sell Document {Note: the file was Validated by DataAnnotation in DTO model} (Note: Uploade Operation must come after all Validation)
                //--------------------------------------------------------------------------------------------------------------------------------------------
                if (sellDto.docment != null && sellDto.docment.Length != 0)
                {
                    // path for Old Document for This Sell Invoice
                    string deletedPath = Path.Combine(hostingEnvironment.WebRootPath, sellToUpdate.docment);
                    // Uploade New Document
                    sellToUpdate.docment = await FileManager.UploadFileAsync(sellDto.docment, hostingEnvironment.WebRootPath, FileSettings.SellDirectory);
                    //Delete Old Document
                    FileManager.RemoveFileFromServer(deletedPath);
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------

                //--------------------------------------------------------------------------------------------------------------------------------------------
                // AuditTrial => Log Update Operation To DataBase 
                //--------------------------------------------------------------------------------------------------------------------------------------------
                AuditTrial aditTrail = new AuditTrial()
                {
                    actionDate = DateTime.UtcNow,
                    ActionId = Models.Action.Update,
                    // This will Throw Exception in case a ControllerName not Match one of Pages Enum Member
                    PageId = Convert.ToInt32(Enum.Parse(typeof(Page.Pages), ControllerContext.ActionDescriptor.ControllerName.ToLower())),
                    recordId = sellToUpdate.sellId,
                    UserId = Convert.ToInt64(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value)
                };
                await db.AuditTrials.AddAsync(aditTrail);
                //--------------------------------------------------------------------------------------------------------------------------------------------

                await db.SaveChangesAsync();

                return Json(new { isError = 0, msg = localizer["SavedSuccessfully"] });
            }
            catch (ApplicationException ex)
            {
                return Json(new
                {
                    isError = 1,
                    msg = ex.Message
                });

            }
            catch (DbUpdateException ex)
            {
                Global.LogException(HttpContext, ex);

                return Json(new
                {
                    isError = 1,
                    msg = localizer["UnableToSaveTryAgainOrCallUs"]
                });
            }
            // Create New Sell_Details
            // Use New Sell_Details to Update Location_Qty {Decrease Operation}
            // Update Sell Obj Values
            // Insert Aduit Trails {Update Action}

        }

        /// <summary>
        /// 1- Mapping From SellDto to  Sell Object . 
        /// 2- determine Sell_State whether its Return Invoice or New Invoice . 
        /// 3- based on Sell_State Location_Qty will be decreased or increased . 
        /// 4- Validate that requsted qty available and selected Location are valid or loggedInUser . 
        /// 5- Calculate { total price , total quntity } . 
        /// </summary>

        /// <param name="sell">Mapping Destination </param>
        /// <param name="sellDto">Mapping  Source </param>
        /// Exceptions:
        ///  T: ApplicationException: in case un valid data for example : requsted quntity not available
        /// 
        /// <returns></returns>
        private async Task PrepareSellObjectAsync(Sell sell, SellDto sellDto)
        {
            // Mapping Sell Object and Sell.Sell_Details Collection
            mapper.Map<SellDto, Sell>(sellDto, sell);
            sell.Sell_Details = mapper.Map<ICollection<Sell_DetailsDto>, ICollection<Sell_Details>>(sellDto.Sell_DetailsDto);

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Set Sell State {new invoice or returned invoice }
            // determine whether the Quantity in the Store will Increased or decrease 
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            int minusOrPlus; //(1 or -1) In case (+1) mean Location_Qty will Increased in amount]|[ In Case (-1) LocationQty will decreased in amount
            if (sellDto.isReturn)
            {
                sell.Sell_StateId = Sell_State.Refunded;// Returned Invoice
                minusOrPlus = 1;  // In case (+1) mean Location_Qty will Increased in amount
            }
            else
            {
                sell.Sell_StateId = Sell_State.New; // New Invoice
                minusOrPlus = -1;//In Case (-1) LocationQty will decrease in amount
            }

            // Products that will be Decreased or Increased in Quantity From Location based on its NewSell or Return
            var productsIDs = sell.Sell_Details.Select(d => d.ProductId);

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Get Location_Qty Entity and Product Price For each Product
            //  { Note : i added condition to validate the location_Qty based on his Branch so user cant hack and send id for location in other branch}
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            int UserBranchId = Convert.ToInt32(User.FindFirst(ClaimName.BranchId).Value);
            var locationId = sell.LocationId;
            var DetailsQtyAndPrices = await db.Location_Qty.Where(r => productsIDs.Contains(r.ProductId) && r.LocationId == locationId && r.Location.BranchId == UserBranchId).Select(r => new { LocationQty = r, r.Product.price }).ToListAsync();
            if (DetailsQtyAndPrices == null || DetailsQtyAndPrices.Count == 0)
                throw new ApplicationException(localizer["QtyNotAvailableOrNotAllowedLocation"]);

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //1- Get Location QTy and Unit Price For Each Sell Details Item
            //2- Update Sell_Details Object For UnitPrice (the accepted UnitPrice from db not user form)
            //3- Check The Availability of Requested Quantity In Case New Invoice and subtract Quantity from the Location_Qty
            //      (In Case Returned Invoice Location_QTy will Increased )
            //4- Calculate Sell TotalPrice 
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            decimal totalPrice = 0;

            foreach (var detailsItem in sell.Sell_Details)
            {
                var prodID = detailsItem.ProductId;
                var LocationQtyAndPrice = DetailsQtyAndPrices.Single(r => r.LocationQty.ProductId == prodID);
                detailsItem.unitPrice = LocationQtyAndPrice.price;
                Location_Qty LocationQTY = LocationQtyAndPrice.LocationQty;

                // Check the availability of Requested Quantity Just In Case New Sell Invoice
                if (sell.isReturn == false && LocationQTY.qty < detailsItem.qty)
                    throw new ApplicationException(localizer["QuantityNotAvailable"]);

                LocationQTY.qty += (minusOrPlus * detailsItem.qty);// example : [20 + (1*10) = 30] and [20 + (-1*10) =10]

                // Calculate Details Item Total Price
                totalPrice += calcTotal(detailsItem.discount, detailsItem.isPercentDiscount, detailsItem.qty, detailsItem.unitPrice);

            }

            //--------------------------------------------------------------------------------------------------------------------------------------------
            // Calculate Total Quantity & Calculate Total Price 
            //--------------------------------------------------------------------------------------------------------------------------------------------
            sell.totalQty = sell.Sell_Details.Select(r => r.qty).Sum();

            decimal TaxAmount = (sell.isPercentTax) ? ((totalPrice * sell.tax) / 100) : sell.tax;
            totalPrice += decimal.Round(TaxAmount, 2);

            decimal GlobalDiscountAmount = (sell.isPercentDiscount) ? ((totalPrice * sell.discount) / 100) : sell.discount;
            totalPrice -= decimal.Round(GlobalDiscountAmount, 2);


            sell.totalPrice = totalPrice;

            //--------------------------------------------------------------------------------------------------------------------------------------------

        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //This Action Serve Select2 plugin Auto Complete https://select2.org/data-sources/ajax
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> getCustomers(string q, int page = 1)
        {

            var take = 20; // number of rows each page
            var skip = (page - 1) * take; // Start From Row Number ? (Note Skip Start From 0 index)

            var search = q.ToLower().Trim();

            var customersQuery = db.Customers.Where(g => g.isDeleted == false && g.isActive && g.customerName.ToLower().Contains(search)).AsNoTracking();
            var total_count = await customersQuery.CountAsync();

            var results = await customersQuery.Select(r => new { id = r.customerId, text = r.customerName }).OrderBy(g => g.text).Skip(skip).Take(take).ToListAsync();
            var obj = new { total_count = total_count, results = results };

            return Json(obj);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        // This Action Serve Select2 plugin Auto Complete https://select2.org/data-sources/ajax
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> getProducts(string q, int page = 1)
        {

            var take = 20; // number of rows each page
            var skip = (page - 1) * take; // Start From Row Number ? (Note Skip Start From 0 index)
            var search = q.ToLower().Trim();

            var productsQuery = db.Products.Where(g => g.isDeleted == false && g.isActive && g.productName.Contains(search)).AsNoTracking();
            var results = await productsQuery.Select(r => new { id = r.productId, text = r.productName, r.barcode, r.code, r.Brand.companyName }).OrderBy(g => g.text).Skip(skip).Take(take).ToListAsync();
            var total_count = await productsQuery.CountAsync();

            var obj = new { total_count = total_count, results = results };

            return Json(obj);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        // When User Select Product {onChange Event On Select box : Call Server via Ajax and Get Product Avilable Qty }
        // @param proId : product Id 
        // @param locationId : location Id
        // 
        // @Return : current quantity in specific location for specific product and its price
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> GetProductAvilableQty(int proId, int locationId)
        {
            try
            {
                // Get Price & Quantity For Product in Specific Location
                var result = await db.Location_Qty.Include(q => q.Product).Where(q => q.LocationId == locationId && q.ProductId == proId).Select(q => new { q.qty, q.Product.price }).SingleOrDefaultAsync();
                return Json(new { qty = result.qty, price = result.price });
            }
            catch (Exception ex)
            {
                return Json(new { isError = 1, msg = ex.Message });
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        // When User Select Customer {onChange Event On Select box : Call Server via Ajax and Get Customer Discount And Tax }
        // @param id : customer id
        //--------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> GetCustomerDiscountAndTax(int id)
        {

            try
            {
                CustomerTaxAndDiscount cust = new CustomerTaxAndDiscount()
                {
                    discountValue = 0,
                    isDiscountPrecent = true,
                    isTaxPrecent = true,
                    taxValue = 0
                };
                var customerTaxAndDiscount = await db.Customers.Where(g => g.customerId == id)
                    .Select(c => new CustomerTaxAndDiscount
                    {
                        discountValue = c.Discount.discountValue,
                        isDiscountPrecent = c.Discount.isPercent,
                        taxValue = c.Tax.taxValue,
                        isTaxPrecent = c.Tax.isPercent
                    })
                    .FirstOrDefaultAsync();

                if (customerTaxAndDiscount != null)
                {
                    if (customerTaxAndDiscount.discountValue > 0)
                    {
                        cust.discountValue = customerTaxAndDiscount.discountValue;
                        cust.isDiscountPrecent = customerTaxAndDiscount.isDiscountPrecent;
                    }

                    if (customerTaxAndDiscount.taxValue > 0)
                    {
                        cust.taxValue = customerTaxAndDiscount.taxValue;
                        cust.isTaxPrecent = customerTaxAndDiscount.isTaxPrecent;
                    }
                }
                return Json(cust);

            }
            catch (Exception ex)
            {
                return Json(new { isError = 1, msg = ex.Message });
            }
        }


        /// <summary>
        /// Calculate Details Item Total Price
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="isPercentDiscount"></param>
        /// <param name="qty"></param>
        /// <param name="unitPrice"></param>
        /// <returns>decimal</returns>
        public decimal calcTotal(decimal discount, bool isPercentDiscount, decimal qty, decimal unitPrice)
        {
            // Calculate Details Item Total Price
            decimal PriceOfQuantity = (qty * unitPrice);
            PriceOfQuantity = decimal.Round(PriceOfQuantity, 2);
            decimal discountAmount = (isPercentDiscount) ? ((PriceOfQuantity * discount) / 100) : discount;
            discountAmount = decimal.Round(discountAmount, 2);

            return (PriceOfQuantity - discountAmount);

        }
    }
}