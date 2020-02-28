using Homework.Plugins.Core.Attributes;
using Homework.Plugins.Core.Contracts;
using Homework.Plugins.Core.Enums;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Homework.Plugins.XmlConverter
{
    [ConverterPluginAttributes(ConverterType.Xml)]

    public class XmlConverter : IExport
    {
        public ConverterType ConverterType => ConverterType.Xml;

        public string Export<T>(T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            string result = string.Empty;
            using (MemoryStream mem = new MemoryStream())
            {
                using (var xw = XmlWriter.Create(mem))
                {
                    serializer.Serialize(xw, value);
                    result = Encoding.UTF8.GetString(mem.ToArray());
                    string utf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                    if (result.StartsWith(utf8))
                        result = result.Remove(0, utf8.Length);
                    return result;
                }
            }
        }

    }
}
