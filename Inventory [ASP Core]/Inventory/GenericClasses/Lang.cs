using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Inventory.GenericClasses
{
    //************************************************************************************************************************************************************************************************************************************
    //=>This EnCapsulation Class For Supported Languages used in our Website
    //=>Note: You Have To Add supportedCultures in Startup Class in ConfigureServices For More Information => https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-2.2
    //=>Note(Lang.js file): For Front End and For JavaScript Localization and Globalization There is Lang.js file responsible for Localization JavaScript Messages and Plugins likse select2 or bootstrap-table or any plugin need to be localized
    //************************************************************************************************************************************************************************************************************************************

    public static class Lang
    {

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Languages (CULTURES)
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static readonly string Arabic = "ar";
        public static readonly string English_UK = "en-GB"; // English United Kingdom
        public static readonly string French = "fr";

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Default Language (Default CULTURE)
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static readonly string DefaultLang = English_UK;

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // List of Supported Languages
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //public static IList<CultureInfo> supportedCultures = new List<CultureInfo> {

        //        new CultureInfo(Arabic),
        //        new CultureInfo(English_UK), // English United Kingdom
        //        new CultureInfo(French)

        //};

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Layout Directions To Use it in => <html dir="?">
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static readonly string dir_rtl = "rtl";
        public static readonly string dir_ltr = "ltr";

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // supportedCulturesDictionary Key=> lang id in database in Language Table 
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static Dictionary<int, CultureInfo> supportedCulturesDictionary = new Dictionary<int, CultureInfo> {

            {1, new CultureInfo(Arabic) },
            {2, new CultureInfo(English_UK) }, // English United Kingdom
            {3, new CultureInfo(French) }

        };

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // List of Supported Languages
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IList<CultureInfo> supportedUICultures = supportedCulturesDictionary.Values.ToList();
        public static IList<CultureInfo> supportedCultures = new List<CultureInfo>() {
            new CultureInfo(English_UK), //In Arabic => Note : i want to display  strings with arabic localization only but for date , numbers , currency in english fotmat So { UICulture: ar and Cultuer: en}
            new CultureInfo(English_UK),
            new CultureInfo(French) };

        public static string getUserLangName(HttpRequest Request)
        {


            // Retrieves the requested culture
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var culture = rqf.RequestCulture.Culture;

            return culture.Name;
        }

        public static int geUsertLangID(HttpRequest Request)
        {
            // Retrieves the requested culture
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var culture = rqf.RequestCulture.Culture;
            var LangId = supportedCulturesDictionary.FirstOrDefault(x => x.Value.Name == culture.Name).Key;

            return LangId;
        }
    }
}
