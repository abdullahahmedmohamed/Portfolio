using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.GenericClasses.ManagingFiles
{
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //         +++++++++++++++++++++ 
    // ------> |Very Important Note| <------
    //         +++++++++++++++++++++
    //  You Have To Intial FileSettings , FileValidationConstraints For each New Application
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public enum ValidFormat { Img, document, MixDocImg }

    public static class FileSettings
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // All Folder Paths For all Uploaded Files in Application
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public const string UploadDirectory = "Uploads";
        public const string UserDirectory = UploadDirectory + @"/Users";
        public const string BuyDirectory = UploadDirectory + @"/Buy";
        public const string CustomersDirectory = UploadDirectory + @"/Customers";
        public const string ProductsDirectory = UploadDirectory + @"/Products";
        public const string SellDirectory = UploadDirectory + @"/Sell";
        public const string SettingsDirectory = UploadDirectory + @"/Settings";
        public const string SuppliersDirectory = UploadDirectory + @"/Suppliers";


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Allowed Microsoft office mime types && Extensions
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        /////---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ///// for Microsoft Office Documents i made Allowed MimeTypes and Extensions separated on other types of documents because in some times that will be useful to validate uploaded file if it's microsoft document
        /////---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static ReadOnlyCollection<string> AllowedMimeTypes_MicrosoftOffice { get; } = new ReadOnlyCollection<string>(
            new string[] { "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" });

        public static ReadOnlyCollection<string> AllowedExtensions_MicrosoftOffice { get; } = new ReadOnlyCollection<string>(
        new string[] { ".xlsx", ".xls", ".doc", ".docx" });

        // General Docs

        public static ReadOnlyCollection<string> AllowedMimeTypes_GeneralDocuments { get; } = new ReadOnlyCollection<string>(
            new string[] { "text/plain", "application/pdf" });

        public static ReadOnlyCollection<string> AllowedExtensions_GeneralDocuments { get; } = new ReadOnlyCollection<string>(
        new string[] { ".txt", ".pdf" });

        // Images

        public static ReadOnlyCollection<string> AllowedMimeTypes_Images { get; } = new ReadOnlyCollection<string>(
        new string[] { "image/jpg", "image/jpeg", "image/pjpeg", "image/x-png", "image/png" });

        public static ReadOnlyCollection<string> AllowedExtensions_Images { get; } = new ReadOnlyCollection<string>(
        new string[] { ".jpg", ".png", ".jpeg" });

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // default Max Size
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public const int DefaultMaxSize = 500 * 1024;    // 512 KB



        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //  @param enum ValidFormat : so you Can Easily Pass Valid Format For File and get back the right Conditions and Constraints to validate that file
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static FileValidationConstraints fileValidationConstraints(ValidFormat fileFormat)
        {
            FileValidationConstraints Constraints;

            switch (fileFormat)
            {
                case ValidFormat.Img:
                    Constraints = ImgConstraints();
                    break;
                case ValidFormat.document:
                    Constraints = DocumentConstraints();
                    break;
                case ValidFormat.MixDocImg:
                    Constraints = MixDocAndImgConstraints();
                    break;
                default:
                    throw new Exception(" You must specify some conditions and restrictions to adjust the file validation process");

            }
            return Constraints;
        }





        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // return Object of FileValidationConstraints with Default Image Max Size and Default Allowed MimeTypes & Extensions  For Image 
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static FileValidationConstraints ImgConstraints()
        {
            FileValidationConstraints Constraints = new FileValidationConstraints();
            Constraints.FileMaximumBytes = DefaultMaxSize;


            Constraints.AllowedMimeTypes = new List<string>();
            Constraints.AllowedMimeTypes.AddRange(AllowedMimeTypes_Images);

            Constraints.AllowedExtension = new List<string>();
            Constraints.AllowedExtension.AddRange(AllowedExtensions_Images);

            return Constraints;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // return Object of FileValidationConstraints with Default File Max Size and Default Allowed MimeTypes & Extensions  For Document File
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static FileValidationConstraints DocumentConstraints()
        {
            FileValidationConstraints Constraints = new FileValidationConstraints();
            Constraints.FileMaximumBytes = DefaultMaxSize;


            Constraints.AllowedMimeTypes = new List<string>();
            // Add Accepted MimeTypes For Microsoft Office for example : application/msword , ...
            Constraints.AllowedMimeTypes.AddRange(AllowedMimeTypes_MicrosoftOffice);
            // Add Accepted MimeTypes In General without  Microsoft Office mime types  for example : "text/plain", "application/pdf",...
            Constraints.AllowedMimeTypes.AddRange(AllowedMimeTypes_GeneralDocuments);


            Constraints.AllowedExtension = new List<string>();
            // Add Accepted Extensions For Microsoft Office for example : doc,docx , ...
            Constraints.AllowedExtension.AddRange(AllowedExtensions_MicrosoftOffice);
            // Add Accepted Extensions In General without  Microsoft Office Extensions for example : .pdf,.txt , ...
            Constraints.AllowedExtension.AddRange(AllowedExtensions_GeneralDocuments);

            return Constraints;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // return Object of FileValidationConstraints with Default File Max Size and Default Allowed MimeTypes & Extensions For Document File  And ImgFile
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static FileValidationConstraints MixDocAndImgConstraints()
        {

            FileValidationConstraints Constraints = new FileValidationConstraints();
            Constraints.FileMaximumBytes = DefaultMaxSize;


            Constraints.AllowedMimeTypes = new List<string>();
            // Add Accepted MimeTypes For Microsoft Office for example : application/msword , ...
            Constraints.AllowedMimeTypes.AddRange(AllowedMimeTypes_MicrosoftOffice);
            // Add Accepted MimeTypes In General without  Microsoft Office mime types  for example : "text/plain", "application/pdf",...
            Constraints.AllowedMimeTypes.AddRange(AllowedMimeTypes_GeneralDocuments);
            // Add Accepted MimeTypes For Images for example : "Image/png",...
            Constraints.AllowedMimeTypes.AddRange(AllowedMimeTypes_Images);

            Constraints.AllowedExtension = new List<string>();
            // Add Accepted Extensions For Microsoft Office for example : doc,docx , ...
            Constraints.AllowedExtension.AddRange(AllowedExtensions_MicrosoftOffice);
            // Add Accepted Extensions In General without  Microsoft Office Extensions for example : .pdf,.txt , ...
            Constraints.AllowedExtension.AddRange(AllowedExtensions_GeneralDocuments);
            // Add Accepted Extensions For Images for example : .png, ...
            Constraints.AllowedExtension.AddRange(AllowedExtensions_Images);

            return Constraints;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //@param (int) FileMaximumBytes : Maximum Size For The File In Bytes
        //@param (List<string>) AllowedMimeTypes : List of Allowed Mime types to Validate Uploaded File
        //@param (List<string>) AllowedExtension : List of Allowed Extensions to Validate Uploaded File
        //
        //return Object of FileValidationConstraints with File Max Size and Allowed MimeTypes & Extensions For Document File  
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static FileValidationConstraints CustomConstraints(int FileMaximumBytes, List<string> AllowedMimeTypes, List<string> AllowedExtension)
        {
            FileValidationConstraints Constraints =
                new FileValidationConstraints { FileMaximumBytes = FileMaximumBytes, AllowedMimeTypes = AllowedMimeTypes, AllowedExtension = AllowedExtension };

            return Constraints;
        }

    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // This Class responsible for initialize Uploaded File Configration (Constraints) according to requirements of the Application        
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public class FileValidationConstraints
    {
        public int FileMaximumBytes { set; get; }
        public List<string> AllowedMimeTypes { set; get; }
        public List<string> AllowedExtension { set; get; }

    }


}
