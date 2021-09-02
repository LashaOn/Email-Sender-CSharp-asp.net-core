using emailSender.Data;
using emailSender.Modals.Contact;
using emailSender.Modals.EmailInfo;
using emailSender.Services.ExcelMapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using emailSender.Services.EmailSender;
using IFileUploader = emailSender.Services.FileUploader.IFileUploader;

namespace emailSender.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly IExcelMapping _excelMapping;
        private readonly IFileUploader _fileUploader;
        private readonly IEmailSender _emailSender;
        private readonly ContactContext _context;
        public List<ContactViewModel> Contacts { get; set; }
        public static EmailInfo Info { get; set; }

        public IndexModel(IFileUploader fileUploader, ContactContext context , IExcelMapping excelMapping , IEmailSender emailSender)
        {
            _fileUploader = fileUploader;
            _context = context;
            _excelMapping = excelMapping;
            _emailSender = emailSender;
            Contacts = new List<ContactViewModel>();
        }

        public void OnGet()
        {
            //send contact model to view
            Contacts = _context.Contacts.Select(x => new ContactViewModel
            {
                Id=x.Id,
                Name = x.Name,
                Family = x.Family,
                Email = x.Email
            }).ToList();
        }

        public IActionResult OnPostAddContact( AddContact command)
        {
            //add new contact
            if (ModelState.IsValid)
            {
                var contact = new Contact(command.Name, command.Family, command.Email);
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");

        }

        public IActionResult OnPostExcelFile(IFormFile file)
        {
            //save file
            var filePath=_fileUploader.Upload(file);
            //save excel file data into database
            _excelMapping.MapExcel(filePath);

            return RedirectToPage("./Index");
        }

        public void OnPostEmailInfo(EmailInfoViewModel command)
        {
            
            if (ModelState.IsValid)
            {
                Info = new EmailInfo(command.SenderName, command.Title, command.SenderEmail, command.SenderPass,
                    command.EmailThem, command.Host, command.Port, command.Ssl);

                TempData["success"] = "saved . chose your contact and send email. - ثبت شد . مخاطبین را اضافه و ایمیل را ارسال کنید";
              
            }
            else
            {
                TempData["Error"] = "Could not saved - ثبت نشد .";
            }

        }

        public void OnPostSend()
        {
            var con = _context.Contacts.ToList();
            foreach (var contact in con)
            {
                _emailSender.SendEmail(Info.SenderName, Info.SenderEmail, Info.SenderPass, Info.Title, Info.EmailThem, Info.Host, Info.Port, Info.Ssl, contact.Name, contact.Email);
            }
            
        }


    }
}
