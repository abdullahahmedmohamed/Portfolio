#pragma checksum "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e569c929fff426609cc607211c597d6bd2bec1d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PagesJavaScriptMsgsPartial), @"mvc.1.0.view", @"/Views/Shared/_PagesJavaScriptMsgsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_PagesJavaScriptMsgsPartial.cshtml", typeof(AspNetCore.Views_Shared__PagesJavaScriptMsgsPartial))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\_ViewImports.cshtml"
using Inventory;

#line default
#line hidden
#line 2 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\_ViewImports.cshtml"
using Inventory.Models;

#line default
#line hidden
#line 3 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\_ViewImports.cshtml"
using Action =Inventory.Models.Action;

#line default
#line hidden
#line 8 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#line 11 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\_ViewImports.cshtml"
using Inventory.GenericClasses;

#line default
#line hidden
#line 13 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\_ViewImports.cshtml"
using StackExchange.Profiling;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e569c929fff426609cc607211c597d6bd2bec1d9", @"/Views/Shared/_PagesJavaScriptMsgsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fe822901eaaf78f5a79172990a82acbdcf19b1b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PagesJavaScriptMsgsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 54, true);
            WriteLiteral("<script>\r\n\r\n    // Sell.js\r\n    var PrintReportMsg = \"");
            EndContext();
            BeginContext(55, 27, false);
#line 4 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                     Write(localizer["PrintReportMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(82, 53, true);
            WriteLiteral("\";\r\n\r\n    // SellAdd.js\r\n    var AvailableQtyMsg =  \"");
            EndContext();
            BeginContext(136, 28, false);
#line 7 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                       Write(localizer["AvailableQtyMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(164, 39, true);
            WriteLiteral("\";\r\n    var DicountLowrThanZeroMsg =  \"");
            EndContext();
            BeginContext(204, 35, false);
#line 8 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                              Write(localizer["DicountLowrThanZeroMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(239, 41, true);
            WriteLiteral("\";\r\n    var FailToConnectToServerMsg =  \"");
            EndContext();
            BeginContext(281, 37, false);
#line 9 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                                Write(localizer["FailToConnectToServerMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(318, 42, true);
            WriteLiteral("\";\r\n    var InvoiceDetailsRequiredMsg =  \"");
            EndContext();
            BeginContext(361, 38, false);
#line 10 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                                 Write(localizer["InvoiceDetailsRequiredMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(399, 35, true);
            WriteLiteral("\";\r\n    var LocationRequiredMsg = \"");
            EndContext();
            BeginContext(435, 32, false);
#line 11 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                          Write(localizer["LocationRequiredMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(467, 43, true);
            WriteLiteral("\";\r\n    var PleaseEnterAvailableQtyMsg =  \"");
            EndContext();
            BeginContext(511, 39, false);
#line 12 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                                  Write(localizer["PleaseEnterAvailableQtyMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(550, 51, true);
            WriteLiteral("\";\r\n    var PleaseEnterDiscountZeroOrHigherMsg =  \"");
            EndContext();
            BeginContext(602, 47, false);
#line 13 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                                          Write(localizer["PleaseEnterDiscountZeroOrHigherMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(649, 45, true);
            WriteLiteral("\";\r\n    var PleaseEnterInvoiceDetailsMsg =  \"");
            EndContext();
            BeginContext(695, 41, false);
#line 14 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                                    Write(localizer["PleaseEnterInvoiceDetailsMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(736, 36, true);
            WriteLiteral("\";\r\n    var PleaseEnterPriceMsg =  \"");
            EndContext();
            BeginContext(773, 32, false);
#line 15 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                           Write(localizer["PleaseEnterPriceMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(805, 34, true);
            WriteLiteral("\";\r\n    var PleaseEnterQtyMsg =  \"");
            EndContext();
            BeginContext(840, 30, false);
#line 16 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                         Write(localizer["PleaseEnterQtyMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(870, 40, true);
            WriteLiteral("\";\r\n    var PleaseSelectLocationMsg =  \"");
            EndContext();
            BeginContext(911, 36, false);
#line 17 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                               Write(localizer["PleaseSelectLocationMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(947, 39, true);
            WriteLiteral("\";\r\n    var PleaseSelectProductMsg =  \"");
            EndContext();
            BeginContext(987, 35, false);
#line 18 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                              Write(localizer["PleaseSelectProductMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1022, 38, true);
            WriteLiteral("\";\r\n    var ProductNameRequiredMsg = \"");
            EndContext();
            BeginContext(1061, 35, false);
#line 19 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                             Write(localizer["ProductNameRequiredMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1096, 38, true);
            WriteLiteral("\";\r\n    var ProductQtyRequiredMsg =  \"");
            EndContext();
            BeginContext(1135, 34, false);
#line 20 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                             Write(localizer["ProductQtyRequiredMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1169, 42, true);
            WriteLiteral("\";\r\n    var ProductQtyNotAvailableMsg =  \"");
            EndContext();
            BeginContext(1212, 38, false);
#line 21 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                                 Write(localizer["ProductQtyNotAvailableMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1250, 32, true);
            WriteLiteral("\";\r\n    var RemainingQtyMsg =  \"");
            EndContext();
            BeginContext(1283, 28, false);
#line 22 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                       Write(localizer["RemainingQtyMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1311, 32, true);
            WriteLiteral("\";\r\n    var RequestedQtyMsg =  \"");
            EndContext();
            BeginContext(1344, 28, false);
#line 23 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                       Write(localizer["RequestedQtyMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1372, 32, true);
            WriteLiteral("\";\r\n    var ReturndedQtyMsg =  \"");
            EndContext();
            BeginContext(1405, 28, false);
#line 24 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                       Write(localizer["ReturndedQtyMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1433, 37, true);
            WriteLiteral("\";\r\n    var UnitPriceRequiredMsg =  \"");
            EndContext();
            BeginContext(1471, 33, false);
#line 25 "E:\Work Partition\Web Development\Mostafa ElShenawy\Work Projects\InventoryCore\Inventory\Inventory\Views\Shared\_PagesJavaScriptMsgsPartial.cshtml"
                            Write(localizer["UnitPriceRequiredMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(1504, 56, true);
            WriteLiteral("\";\r\n\r\n   \r\n    \r\n    \r\n    \r\n    \r\n    \r\n    \r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591