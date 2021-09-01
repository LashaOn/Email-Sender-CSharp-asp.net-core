using System.IO;
using Microsoft.AspNetCore.Http;

namespace emailSender.Application.FileUploader
{
    public interface IFileUploader
    {
        string Upload(IFormFile file );
    }
}
