using Homework.Plugins.Core.Enums;

namespace Homework.Plugins.Core.Contracts
{
    public interface IExport
    {
        /// <summary>
        /// Get targer output file extension
        /// </summary>
        ConverterType ConverterType { get; }

        /// <summary>
        /// Return to exportable string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Exportable generic type</param>
        /// <returns></returns>
        string Export<T>(T value);

    }
}
