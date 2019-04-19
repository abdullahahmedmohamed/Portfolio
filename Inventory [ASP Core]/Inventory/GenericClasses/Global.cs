using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmahCore;
using Microsoft.AspNetCore.Http;


namespace Inventory.GenericClasses
{
    public static class Global
    {

        /// <summary>
        /// Collect All Error Messages From ControllerBase.ModelState and return them as Enumerable so you can loop throw them 
        /// </summary>
        /// <param name="ModelState"></param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<string> ModelErrors(ModelStateDictionary ModelState)
        {
            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return allErrors.Select(e => e.ErrorMessage);
        }

        /// <summary>
        /// Collect All Error Messages From ControllerBase.ModelState and return them as sting seperated for example by coma {,} => "error1,error2,error3" 
        /// </summary>
        /// <param name="ModelState"></param>
        /// <param name="separator"></param>
        /// <returns>String</returns>
        public static string ModelErrorsToJoinString(ModelStateDictionary ModelState ,string separator)
        {

            var errorMessages = ModelErrors(ModelState);

            return string.Join(separator, errorMessages);
        }

        /// <summary>
        ///  Custom Mehtod to Logging Application Exceptions 
        ///  {Note : i use ElmahCore}
        /// </summary>
        /// <param name="HttpContext"></param>
        /// <param name="ex"></param>
        public static void LogException(HttpContext HttpContext,Exception ex)
        {
            //Log the error to elmahCore
            HttpContext.RiseError(new InvalidOperationException("Custom Log", ex));
        }

    }
}
