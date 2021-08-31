using System.IO;
using _0_framework.FileUploader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace emailSender
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}\\ExcelFiles\\";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var filePath = $"{directoryPath}\\{file.FileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);

            return filePath;
        }
    }
}
