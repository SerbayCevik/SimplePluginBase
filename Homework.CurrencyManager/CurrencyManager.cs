using Homework.CurrencyManagement.Models;
using Homework.CurrencyManagement.Utils;
using Homework.Plugins.Core.Contracts;
using Homework.Plugins.Core.Enums;
using Homework.Plugins.Core.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Linq;

namespace Homework.CurrencyManagement
{
    public class CurrencyManager
    {

        public IEnumerable<Currency> _currencies { get;private set; }
        private const string _url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        private IExport _exporter;
        protected string _exportableString;
        public CurrencyManager()
        {

        }

        public CurrencyManager Data()
        {
            if (_currencies == null)
                _currencies = GetCurrencies();
            return this;
        }
        private IEnumerable<Currency> GetCurrencies()
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

        public CurrencyManager Export(ConverterType converterType)
        {
            _exporter = new ConverterFactory().GetConverterInstance(converterType);
            _exportableString = _exporter.Export(_currencies.ToList());
            return this;

        }

        public CurrencyManager Filter(Expression<Func<Currency, bool>> predicate)
        {
            _currencies = _currencies.Filter(predicate);
            return this;
        }
        public CurrencyManager OrderBy(Expression<Func<Currency, string>> predicate, OrderType orderType)
        {
            _currencies = _currencies.OrderBy(predicate, orderType);
            return this;
        }

        public void Save(string path, string fileName)
        {
            using (StreamWriter wrt = new StreamWriter(File.Open(Path.Combine(path, fileName), FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite)))
            {
                wrt.Write(this._exportableString);
                wrt.Flush();
            }
        }


    }
}
