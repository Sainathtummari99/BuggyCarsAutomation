using AngleSharp.Io;
using NPOI.SS.Formula.Functions;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework
{
     class DataReader {

        [Test]

        public void excelDataReadoSecnario1() {
            string path = @"C:\Users\saina\Desktop\TestData.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0);
            var scenario1 = sheet.GetRow(1);
            var loginName1 = scenario1.GetCell(0).StringCellValue.Trim();
            var firstName1 = scenario1.GetCell(1).StringCellValue.Trim();
            var lastName1 = scenario1.GetCell(2).StringCellValue.Trim();
            var password1 = scenario1.GetCell(3).StringCellValue.Trim();
            var confirmpassword1 = scenario1.GetCell(4).StringCellValue.Trim();
            var expectedMessage1 = scenario1.GetCell(5).StringCellValue.Trim();

        }
    }
}
