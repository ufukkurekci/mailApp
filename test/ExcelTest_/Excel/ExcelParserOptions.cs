using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace file_demo__01.Excel
{
    public class ExcelParserOptions
    {
        public  string FilePath { get;  }
        public  string WorksheetName { get; set; }
        public int HeaderRow { get; set; }

        public ExcelParserOptions(string filePath)
        {
            FilePath = filePath;
        }
    }


    public class ColumnInfo
    {
        public int Column { get; set; }
        public string Name { get; set; }

        public string Value { get; set; }
    }
}