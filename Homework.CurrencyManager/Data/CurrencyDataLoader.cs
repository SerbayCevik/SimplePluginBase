using Homework.CurrencyManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Homework.CurrencyManagement.Data
{
    public class CurrencyDataLoader
    {
        private const string _url = "https://www.tcmb.gov.tr/kurlar/today.xml";

        public  IEnumerable<Currency> GetData()
        {
            try
            {
                using WebClient client = new WebClient();
                var result = client.DownloadString(_url);
                using (TextReader textReader = new StringReader(result))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TCMBCurrency));
                    var tcmbCurrency = (TCMBCurrency)serializer.Deserialize(textReader);
                    return tcmbCurrency.Currencies;
                }
            }
            catch (Exception)
            {
                throw new Exception("An Exception occured while download currencies... ");
            }
        }
    }
}
