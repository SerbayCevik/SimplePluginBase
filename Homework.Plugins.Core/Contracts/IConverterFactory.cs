using Homework.Plugins.Core.Enums;

namespace Homework.Plugins.Core.Contracts
{
    public interface IConverterFactory
    {
        IExport GetConverterInstance(ConverterType converterType);
    }
}
