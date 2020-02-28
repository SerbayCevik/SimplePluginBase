using Homework.Plugins.Core.Enums;

namespace Homework.Plugins.Core.Contracts
{
    public interface IExport
    {
        ConverterType ConverterType { get; }
        string Export<T>(T value);

    }
}
