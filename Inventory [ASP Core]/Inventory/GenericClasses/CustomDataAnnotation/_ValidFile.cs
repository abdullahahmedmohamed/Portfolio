using Inventory.GenericClasses.ManagingFiles;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.GenericClasses.CustomDataAnnotation
{
    public class _ValidFile : ValidationAttribute
    {
        private ValidFormat fileFormat;
        

        public _ValidFile(ValidFormat _fileFormat)
        {
            fileFormat = _fileFormat;
            
        }
        //-------------------------------------------------------------------------------------------------
        //This return Success whether file is null or it's in a valid format
        //-------------------------------------------------------------------------------------------------
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = (IFormFile)value;

            
            if (file == null || file.Length == 0)
                return ValidationResult.Success;
                

            // Get Default Constraints For Uploaded file to Validate it like {Allowed mimeTypes,MaxSize,Allowed Extentions}
            var Constraints = FileSettings.fileValidationConstraints(fileFormat);

            bool valid = ValidateFiles.IsValidFile(file, Constraints);

            if (valid)
                return ValidationResult.Success;

            // UnValid Message
            string message = String.Format(ErrorMessage, String.Join('/', Constraints.AllowedExtension), (Constraints.FileMaximumBytes / 1024));
            return new ValidationResult(message);
        }
    }
}
