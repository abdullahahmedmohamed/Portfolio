using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Inventory.AccountTooles;
using Inventory.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Inventory.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        // Can be passed via <page-link controller="..." />. 
        // PascalCase gets translated into kebab-case.
        public string controller { get; set; }

        public string action { get; set; }

        public int? actionId { get; set; }

        //this flag to determine if is the parent tag is <li> or no 
        public bool? liTag { get; set; }

        public ClaimsPrincipal User { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Set Default Value just in case ActionId == null 
            int _actionID = this.actionId ?? Models.Action.Read;

            // before drawing page link i have to check if logged in user have permission for this page or not


            // Check if Logged In User have permission To Read Specific Page for example => ControllerName: Customer , ActionId:1 (Action.Read) 
            bool isAllow = UserPagePermission.PageActionPermission(User, controller, _actionID);

            if (isAllow)
            {
                
                var href = @"/" + controller + @"/" + action;

                // Draw <a> Tag as Chiled for <li> tag
                if (liTag.HasValue && liTag == true)
                {
                    output.TagName = "li";  // Replaces <pagelink> with <li> tag
                    var content = await output.GetChildContentAsync();
                    var htmlContent = content.GetContent();

                    output.PreContent.SetHtmlContent($@"<a href='{href}'>");
                    output.Content.SetHtmlContent(htmlContent);
                    output.PostContent.SetHtmlContent("</a>");
                }
                else
                { // Draw <a> Tag 
                    output.TagName = "a";    // Replaces <pagelink> with <a> tag
                    output.Attributes.SetAttribute("href", href);
                }

            }
            else
            { // dont draw any html
                output.SuppressOutput();
            }


        }

    }
}
