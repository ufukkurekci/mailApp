using System.Collections.Generic;
using System.Reflection;

namespace file_demo__01.Excel
{
    public interface IExcelParser
    {
        IEnumerable<T> Parser<T>(ExcelParserOptions options) where T : new();
    }
}