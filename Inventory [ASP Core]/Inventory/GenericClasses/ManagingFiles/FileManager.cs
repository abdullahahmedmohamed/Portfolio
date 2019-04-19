using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.GenericClasses.ManagingFiles
{

    public class FileManager
    {

        //--------------------------------------------------------------------------------------------------------------------
        // Usage Example (How To Use DownloadAsync in Controller)
        //--------------------------------------------------------------------------------------------------------------------
        /* 1- inject IHostingEnvironment _hostingEnvironment 
         * 2-
         *  string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
         *  string FullPath = Path.Combine(uploadFolder, fileName);
         *  var f = await GenericClasses.ManagingFiles.FileManager.DownloadAsync(FullPath);
         */


        //--------------------------------------------------------------------------------------------------------------------
        // Explanation
        //--------------------------------------------------------------------------------------------------------------------    
        /* this class is responsible for Upload , Download  , Delete Files from and to the Server
         * 
         * 1-UploadFileWithValidationAsync : perform upload functionality with validation on file extention and mimtype and so on 
         *                  Related Functions => Enum:ValidFormat , Func:GetUniqueFileName()
         *                  
         *                  Params: 
         *                          -File
         *                          -ValidFormat => type of file to valid it if its image or document like word or xlx ..
         *                          -uploadDirectory  example=> ServerPath/wwwroot/Uploads
         *                          
         * 2-UploadFileAsync : perform upload functionality with out validation so you have to validate the file before using it if you need
         *                      
         * 3-DownloadAsync  : Note that Method not download actual file but its return object of class its properties used by FileStreamResult in controller action to return file
         *                  Params: 
         *                          -uploadDirectory  example=> ServerPath/wwwroot/Uploads/fileName.jpg => So We Can Download File From This Folder by file name in this path
         *                  
         *                 Related Functions =>        
         *                          
         *                          -Note That we have Created Custom Class its name (MyFileDetails) this Class has 3 simple propertise MemoryFileContent , ContentType , FileName and these 3 attributes used by FileStreamResult in controller action to return file
         *                          -GetContentType() and GetMimeTypes() => used to get GetContentType of downloaded file 
         *
         * 4-RemoveFileFromServer : This method used to remove file from server
         *                  Params: 
         *                          -Full Path Of file to delete it 
         */


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------------------------------------------
        // perform upload functionality with validation on file extention and mimtype and so on 
        // Return :
        //      1-Upload successful : Return FilePath 
        //      2-Upload failed     : Return Null 
        //--------------------------------------------------------------------------------------------------------------------
        public static async Task<string> UploadFileWithValidationAsync(IFormFile file, ValidFormat fileFormat, string webRootPath , string uploadDirectory)
        {
            bool isValidFormat = false;


            if (file == null || file.Length == 0)
                return null;

            // Get Default Constraints For Uploaded file to Validate it like {Allowed mimeTypes,MaxSize,Allowed Extentions}
            var Constraints = FileSettings.fileValidationConstraints(fileFormat);

            isValidFormat = ValidateFiles.IsValidFile(file, Constraints);

            if (isValidFormat)
                return await UploadFileAsync(file, webRootPath, uploadDirectory);
            
            // Not Valid File
            return null;

        }

        //--------------------------------------------------------------------------------------------------------------------
        // perform upload functionality with out validation so you have to validate the file before using it if you need
        // Return :
        //      1-Upload successful : Return FilePath 
        //      2-Upload failed     : Return Null 
        //--------------------------------------------------------------------------------------------------------------------
        public static async Task<string> UploadFileAsync(IFormFile file,string webRootPath, string uploadDirectory)
        {

            // Generate timestap to combine it with file name to prevent duplication file names
            string newFileName = GetUniqueFileName(file.FileName);

            // example : C://webApplicationFolder/wwwroot/subDirectory/newFileName
            var path = Path.Combine(webRootPath,uploadDirectory, newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newFileName;


        }

        // Generate timestap to combine it with file name to prevent duplication file names
        private static string GetUniqueFileName(string fileName)
        {

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + "_"
                      + unixTimestamp
                      + Path.GetExtension(fileName);
        }


        // This Method get the file by full path and read it in memory then return object that contains MemoryFileContent ,ContentType , FileName so you can use FileResult to download the file
        public static async Task<MyFileDetails> DownloadAsync(string fullPath)
        {

            if (!File.Exists(fullPath))
                return null;

            var memory = new MemoryStream();
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            MyFileDetails fileDetails = new MyFileDetails { MemoryFileContent = memory, ContentType = GetContentType(fullPath), FileName = Path.GetFileName(fullPath) };
            return fileDetails;

        }


        /*
         * i built this class to encapsulate 3 properties that used to create object from FileStreamResult in controller action
         * Example : in your Controller in Download Action =>  return File(FileDetails.Memory, FileDetails.ContentType, FileDetails.FileName);
         */
        public class MyFileDetails
        {
            public MemoryStream MemoryFileContent { get; set; }
            public string ContentType { get; set; }
            public string FileName { get; set; }
        }

        // GetContentType Of the file you want to download
        private static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        // List of Accepted Extensions and MimeTypes used in This Application
        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }


        // return true in case file is deleted or not exists on the server
        public static void RemoveFileFromServer(string fullPath)
        {
            //Maybe error could happen like Access denied or Presses Already User used
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
         
        }
    }
}
