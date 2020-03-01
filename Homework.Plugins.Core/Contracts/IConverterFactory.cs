using Homework.Plugins.Core.Enums;

namespace Homework.Plugins.Core.Contracts
{
    public interface IConverterFactory
    {
        /// <summary>
        /// Create the converter with convert type extension
        /// </summary>
        /// <param name="converterType"> </param>
        /// <returns></returns>
        IExport GetConverterInstance(ConverterType converterType);
    }
}
