using CsvHelper;
using Homework.Plugins.Core.Attributes;
using Homework.Plugins.Core.Contracts;
using Homework.Plugins.Core.Enums;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Homework.Plugins.CsvConverter
{
    [ConverterPluginAttributes(ConverterType.Csv)]
    public class CsvConverter : IExport
    {
        #region IExport Members

        public ConverterType ConverterType => ConverterType.Csv;

        public string Export<T>(T value)
        {
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, cultureInfo: CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(value as List<T>);
                writer.Flush();
                stream.Position = 0;
                var text = reader.ReadToEnd();
                return text;
            }
        }

        #endregion

    }
}
