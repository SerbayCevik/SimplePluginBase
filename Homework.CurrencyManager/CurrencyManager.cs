﻿using Homework.CurrencyManagement.Models;
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
    public class CurrencyManager
    {
        private Lazy<IEnumerable<Currency>> data = new Lazy<IEnumerable<Currency>>(() => new CurrencyDataLoader().GetData());
        private IEnumerable<Currency> Data;
        private IExport _exporter;
        private string _exportableString;

        public CurrencyManager()
        {
            Data = data.Value;
        }
        public CurrencyManager Export(ConverterType converterType)
        {
            _exporter = new ConverterFactory().GetConverterInstance(converterType);
            _exportableString = _exporter.Export(Data.ToList());
            return this;
        }

        public CurrencyManager Filter(Expression<Func<Currency, bool>> predicate)
        {
            Data = Data.Filter(predicate);
            return this;
        }
        public CurrencyManager OrderBy(Expression<Func<Currency, string>> predicate, OrderType orderType)
        {
            Data = Data.OrderBy(predicate, orderType);
            return this;
        }

        public void Save(string path, string fileName)
        {
            using (StreamWriter wrt = new StreamWriter(File.Open(Path.Combine(path, fileName), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                wrt.Write(this._exportableString);
                wrt.Flush();
            }
        }


    }
}
