using Homework.Plugins.Core.Attributes;
using Homework.Plugins.Core.Contracts;
using Homework.Plugins.Core.Enums;
using Newtonsoft.Json;
using System;

namespace Homework.Plugins.JsonConverter
{
    [ConverterPluginAttributes(ConverterType.Json)]

    public class JsonConverter : IExport
    {
        #region IExport Members

        public ConverterType ConverterType => ConverterType.Json;
        public string Export<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        #endregion
    }
}
