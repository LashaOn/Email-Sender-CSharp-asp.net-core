using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IFileUploader = emailSender.Application.FileUploader.IFileUploader;

namespace emailSender.Application.FileUploader
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public  string Upload(IFormFile file)
        {
            //string of file path that we need save them
            var directoryPath = $"{_webHostEnvironment.WebRootPath}\\ExcelFiles\\";

            //cheking the direcrory and create them 
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            
            var filePath = $"{directoryPath}\\{file.FileName}";
            using var output = File.Create(filePath);

            //save file
            file.CopyToAsync(output);

            return filePath;
        }
    }
}
