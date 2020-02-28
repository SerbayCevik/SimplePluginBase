using Homework.CurrencyManagement;
using Homework.Plugins.Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Homework
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = "sample";
            string path = Environment.CurrentDirectory;

            new CurrencyManager()
                .Data()
                .Filter(x => double.Parse(x.ForexBuying,CultureInfo.InvariantCulture) < 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Ascending)
                .Export(ConverterType.Xml)
                .Save(fileName,path);
        }
    }
}
