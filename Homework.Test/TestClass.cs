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
            string fileName = "OutputSample.json";
            string path = AppDomain.CurrentDomain.BaseDirectory + "/OutputFiles";
            new CurrencyManager()
                .Filter(x => decimal.Parse(x.ForexBuying) > 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Descending)
                .Export(ConverterType.Json)
                .Save(path, fileName);
        }

        [TestMethod]
        public void ShouldReturn_CsvOutput_FromSource_FilteredBy_ForexBuying_And_OrdeyBy_CurrencyCode_Descending()
        {
            string fileName = "OutputSample.csv";
            string path = AppDomain.CurrentDomain.BaseDirectory + "/OutputFiles";

            new CurrencyManager()
                .Filter(x => decimal.Parse(x.ForexBuying) > 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Descending)
                .Export(ConverterType.Csv)
                .Save(path, fileName);
        }

        [TestMethod]
        public void ShouldReturn_XmlOutput_FromSource_FilteredBy_ForexBuying_And_OrdeyBy_CurrencyCode_Descending()
        {
            string fileName = "OutputSample.xml";
            string path = AppDomain.CurrentDomain.BaseDirectory + "/OutputFiles";

            new CurrencyManager()
                .Filter(x => decimal.Parse(x.ForexBuying) > 1)
                .OrderBy(x => x.CurrencyCode, OrderType.Descending)
                .Export(ConverterType.Xml)
                .Save(path, fileName);
        }
    }
}
