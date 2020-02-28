using Homework.CurrencyManagement;
using Homework.Plugins.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Homework.Test
{

    [TestClass]
    public class HomeworkUnitTests
    {
        [TestMethod]
        public void ShouldReturn_JsonOutput_FromSource_FilteredBy_ForexBuying_And_OrdeyBy_CurrencyCode_Descending()
        {
            string fileName = "sample.json";
            string path = Environment.CurrentDirectory;

            new CurrencyManager()
                .Data()
                .Filter(x => decimal.Parse(x.ForexBuying) > 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Descending)
                .Export(ConverterType.Json)
                .Save(fileName, path);
        }

        [TestMethod]
        public void ShouldReturn_CsvOutput_FromSource_FilteredBy_ForexBuying_And_OrdeyBy_CurrencyCode_Descending()
        {
            string fileName = "sample.csv";
            string path = Environment.CurrentDirectory;

            new CurrencyManager()
                .Data()
                .Filter(x => decimal.Parse(x.ForexBuying) > 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Descending)
                .Export(ConverterType.Csv)
                .Save(fileName, path);
        }

        [TestMethod]
        public void ShouldReturn_XmlOutput_FromSource_FilteredBy_ForexBuying_And_OrdeyBy_CurrencyCode_Descending()
        {
            string fileName = "sample.xml";
            string path = Environment.CurrentDirectory;

            new CurrencyManager()
                .Data()
                .Filter(x => decimal.Parse(x.ForexBuying) > 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Descending)
                .Export(ConverterType.Xml)
                .Save(fileName, path);
        }
    }
}
