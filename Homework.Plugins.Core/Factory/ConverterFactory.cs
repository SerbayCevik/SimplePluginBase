using Homework.Plugins.Core.Contracts;
using Homework.Plugins.Core.Enums;
using Homework.Plugins.Core.PluginManagement;

namespace Homework.Plugins.Core.Factory
{
    public class ConverterFactory : IConverterFactory
    {
    
        public IExport GetConverterInstance(ConverterType converterType)
        {
            return PluginManager.Converters[converterType];
        }
    }
}
