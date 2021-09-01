using System.Collections.Generic;
using System.IO;
using System.Linq;
using emailSender.Data;
using emailSender.Modals;
using OfficeOpenXml;

namespace emailSender.Application.ExcelMapping
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

            var list = new List<Contact>();

            var existingFile = new FileInfo(filePath);
            using ExcelPackage package = new ExcelPackage(existingFile);

            //get the first worksheet in the workbook
            var worksheet = package.Workbook.Worksheets.First(); 

            int rowCount = worksheet.Dimension.End.Row;  //get row count

            for (int row = 2; row <= rowCount; row++)
            { 
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
