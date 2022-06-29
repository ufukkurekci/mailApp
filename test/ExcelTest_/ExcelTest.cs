using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using file_demo__01.Excel;
using Xunit;
using OfficeOpenXml;



namespace ExcelTest_
{
    public class ExcelParserTest
    {
        private readonly IExcelParser _parser;

        public List<Content> result { get; set; }
        public string excelName;

        public ExcelParserTest()
        {
            _parser = new ExcelParser();
        }

        [Fact]
        public IList<Content> Excel_Parser()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var myDocumentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      

            using (StreamReader sr = File.OpenText(@"C:\Users\ukurekci\Desktop\new\excel.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(s))
                    {
                         excelName = s;
                    }
                }
            }

            //string rootFolder = @"C:\Users\ukurekci\Desktop\foto";
            //string authorsFile = "excel.txt";

            //try
            //{
            //    // Check if file exists with its full path    
            //    if (File.Exists(Path.Combine(rootFolder, authorsFile)))
            //    {
            //        // If file found, delete it    
            //        File.Delete(Path.Combine(rootFolder, authorsFile));
                    
            //    }
                
            //}
            //catch (IOException ioExp)
            //{
            //    Console.WriteLine(ioExp.Message);
            //}




            var excelFilePath = Path.Combine(myDocumentFolder,excelName);
            //var excelFilePath = Path.Combine(myDocumentFolder, "mail.xlsx");

            var options = new ExcelParserOptions(excelFilePath)
            {
                HeaderRow = 1,
                WorksheetName = "Sheet1"

            };

           var result = _parser.Parser<Content>(options).ToList();
            
            //Assert.True(result.Any());
            
           

           

            

            return result;

            
        }
    }

    public class Content
    {
        [Excell("TO")]
        public string TO { get; set; }


        [Excell("CC")]
        public string Cc { get; set; }


        [Excell("BCC")]
        public string Bcc { get; set; }


        [Excell("Subject")]
        public string Subject { get; set; }


        [Excell("attach")]
        public string attach { get; set; }


        [Excell("time")]
        public DateTime Time { get; set; }
    }
}
