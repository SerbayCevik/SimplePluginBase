using Homework.Plugins.Core.Enums;
using System;

namespace Homework.Plugins.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConverterPluginAttributes : Attribute
    {
        public ConverterPluginAttributes(ConverterType converterType)
        {
            _converterType = converterType;
        }

        private ConverterType _converterType;

        public ConverterType ConvertionType
        {
            get { return _converterType; }
            set { _converterType = value; }
        }

    }
}
