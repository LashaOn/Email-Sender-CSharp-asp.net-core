using _0_framework.FileUploader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace emailSender.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFileUploader _fileUploader;

        public IndexModel(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostExcelFile(IFormFile file)
        {
            _fileUploader.Upload(file);

            return RedirectToPage("./Index");
        }
    }
}
