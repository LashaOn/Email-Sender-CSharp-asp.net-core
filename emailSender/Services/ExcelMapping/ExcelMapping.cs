using System.Collections.Generic;
using System.IO;
using System.Linq;
using emailSender.Data;
using emailSender.Modals;
using emailSender.Modals.Contact;
using OfficeOpenXml;

namespace emailSender.Services.ExcelMapping
{
    public class ExcelMapping : IExcelMapping
    {
        private readonly ContactContext _context;

        public ExcelMapping(ContactContext context)
        {
            _context = context;
        }

        public void MapExcel(string filePath)
        {

            /*EPPLUS FOR WORKING BY EXCEL FILE
            https://www.nuget.org/packages/EPPlus/
            Install-Package EPPlus -Version 5.7.4*/


            var existingFile = new FileInfo(filePath);
            using ExcelPackage package = new ExcelPackage(existingFile);

            //get the first worksheet in the workbook
            var worksheet = package.Workbook.Worksheets.First();

            //get row count
            int rowCount = worksheet.Dimension.End.Row;  
            

            for (int row = 2; row <= rowCount; row++)
            { 
                //add excel file data into database
                var contact = new Contact(
                        worksheet.Cells[row, 2].Value.ToString()?.Trim(),
                        worksheet.Cells[row, 3].Value.ToString()?.Trim(),
                        worksheet.Cells[row, 4].Value.ToString()?.Trim()
                        );
                    _context.Contacts.Add(contact);
                    _context.SaveChanges();
                
            }

        }
    }
}
