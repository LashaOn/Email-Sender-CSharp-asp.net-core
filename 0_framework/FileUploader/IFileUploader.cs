using Microsoft.AspNetCore.Http;


namespace _0_framework.FileUploader
{
    public interface IFileUploader
    {
        string Upload(IFormFile file );
    }
}
