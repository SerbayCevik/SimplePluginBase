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
using Homework.CurrencyManagement.Data;

namespace Homework.CurrencyManagement
{
    public sealed class CurrencyManager
    {
        private Lazy<IEnumerable<Currency>> data = new Lazy<IEnumerable<Currency>>(() => new CurrencyDataLoader().GetData());
        private IEnumerable<Currency> Data;
        private IExport _exporter;
        private string _exportableString;

        public CurrencyManager()
        {
            Data = data.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="converterType">specific convert type </param>
        /// <returns>return the specific converter factory </returns>
        public CurrencyManager Export(ConverterType converterType)
        {
            _exporter = new ConverterFactory().GetConverterInstance(converterType);
            _exportableString = _exporter.Export(Data.ToList());
            return this;
        }

        /// <summary>
        /// Filters external source by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public CurrencyManager Filter(Expression<Func<Currency, bool>> predicate)
        {
            Data = Data.Filter(predicate);
            return this;
        }

        /// <summary>
        /// Order external source by predicate with order type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public CurrencyManager OrderBy(Expression<Func<Currency, string>> predicate, OrderType orderType)
        {
            Data = Data.OrderBy(predicate, orderType);
            return this;
        }
        
        /// <summary>
        /// Saves the output file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool Save(string path, string fileName)
        {
            return _exportableString.TrySave(path, fileName);
        }


    }
}
