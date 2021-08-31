using System.Collections.Generic;
using System.Linq;
using _0_framework.FileUploader;
using emailSender.Data;
using emailSender.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace emailSender.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFileUploader _fileUploader;
        private readonly ContactContext _context;
        public AddContact Command { get; set; }
        public List<ContactViewModel> Contacts { get; set; }

        public IndexModel(IFileUploader fileUploader, ContactContext context)
        {
            _fileUploader = fileUploader;
            _context = context;
            Contacts = new List<ContactViewModel>();
        }

        public void OnGet()
        {
            Contacts = _context.Contacts.Select(x => new ContactViewModel
            {
                Id=x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();
        }

        public IActionResult OnPostAddContact(AddContact command)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact(command.Name, command.LastName, command.Email);
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");

        }

        public IActionResult OnPostExcelFile(IFormFile file)
        {
            _fileUploader.Upload(file);

            return RedirectToPage("./Index");
        }
    }
}
