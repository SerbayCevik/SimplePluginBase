using Homework.CurrencyManagement;
using Homework.Plugins.Core.Enums;
using System;
using System.Globalization;

namespace Homework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "OutputSample.csv";
            string path = AppDomain.CurrentDomain.BaseDirectory + "/OutputFiles";

            new CurrencyManager()
                .Filter(x => double.Parse(x.ForexBuying, CultureInfo.InvariantCulture) < 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Ascending)
                .Export(ConverterType.Csv)
                .Save(path, fileName);

            Console.ReadKey();
        }
    }
}
