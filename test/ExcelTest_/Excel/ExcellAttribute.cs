using System;

namespace file_demo__01.Excel
{
    public class ExcellAttribute : Attribute
    {
        public string Name { get; set; }

        public ExcellAttribute(string name)
        {
            Name = name;
        }
    }
}