using Microsoft.AspNetCore.Http;

namespace emailSender.Services.FileUploader
{
    public interface IFileUploader
    {
        string Upload(IFormFile file );
    }
}
