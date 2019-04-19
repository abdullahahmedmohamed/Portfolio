using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.GenericClasses.ManagingFiles
{
    // This Class is responsible for Validate Real MimeTypes of Files To Detect if the file is real Image or real document or not
    public static class ValidateFiles
    {

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //@param (IFormFile) postedFile : the uploaded file
        //@param (FileValidationConstraints) constraints : this object has main Constraints to Validate the File Like Maximum file size and allowed MimeTypes & Extentions
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static bool IsValidFile(IFormFile postedFile, FileValidationConstraints constraints)
        {

            try
            {
                // List of Allowed MimeTypes and Extensions
                List<string> MimeTypes_Allowed = constraints.AllowedMimeTypes;
                List<string> Extension_Allowed = constraints.AllowedExtension;


                //-------------------------------------------
                //  Check the file mime types
                //-------------------------------------------
                string contentType = postedFile.ContentType.ToLower();

                if (!MimeTypes_Allowed.Any(m => m == contentType))
                    return false;


                //-------------------------------------------
                //  Check the file extension
                //-------------------------------------------

                string extension = Path.GetExtension(postedFile.FileName).ToLower();

                if (!Extension_Allowed.Any(e => e == extension))
                    return false;




                //------------------------------------------
                //check whether the file size exceeding the limit or not
                //------------------------------------------ 
                if (postedFile.Length > constraints.FileMaximumBytes)
                {
                    return false;
                }

                //---------------------------------------------------------------------------------------------------------------------------------
                //  Check the Real Mime Type Of File (because maybe user hacked the file and change his name and extension)
                //---------------------------------------------------------------------------------------------------------------------------------

                //MimeTypes is Custom Class not in Asp.net Classes
                var actualType = MimeTypes.getMimeFromFile(postedFile);

                if (!MimeTypes_Allowed.Any(m => m == actualType))
                {
                    // Do Final Validation : check if its MicrosoftOfficeDocument in zip format otherwise return false
                    bool isMSOffice = isMicrosoftOfficeDocument(actualType, contentType, extension);
                    if (!isMSOffice)
                        return false;

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //---------------------------------------------------------------------------------------------------------------------------------
        //  In Some Cases or Some Microsoft Office Versions the doucment get uploaded with actual type as zip file 
        // so in case to validate the actual type of the uploaded file here i will check on the extentions and mimetype to be one of Ms office mimetypes and extentions 
        // 
        // @Return True : in case 
        //                      1-contentType match one of Allowed MS Office Types 
        //                      2-AND extension match one of Allowed MS Office extensions 
        //                      3-AND actual mime Type match one of zip file types
        //---------------------------------------------------------------------------------------------------------------------------------
        public static ReadOnlyCollection<string> zipTypes { get; } = new ReadOnlyCollection<string>(
            new string[] { "application/zip", "application/octet-stream", "application/x-zip-compressed" });

        private static bool isMicrosoftOfficeDocument(string actualType, string contentType, string extension)
        {
            if (!zipTypes.Any(m => m == actualType))
                return false;
            if (!FileSettings.AllowedMimeTypes_MicrosoftOffice.Any(m => m == contentType))
                return false;
            if (!FileSettings.AllowedExtensions_MicrosoftOffice.Any(m => m == extension))
                return false;

            return true;
        }
    }
}
