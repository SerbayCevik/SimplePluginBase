using Homework.Plugins.Core.Attributes;
using Homework.Plugins.Core.Contracts;
using Homework.Plugins.Core.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Homework.Plugins.Core.PluginManagement
{
    public sealed class PluginManager
    {
        private static Dictionary<ConverterType, IExport> _converters;

        public static Dictionary<ConverterType, IExport> Converters
        {
            get
            {
                if (null == _converters)
                    Load();

                return _converters;
            }
        }
        public static void Load()
        {
            if (null == _converters)
                _converters = new Dictionary<ConverterType, IExport>();
            else
                _converters.Clear();

            //Load all marked assemblies with IExport
            List<Assembly> pluginAssemblies = LoadPlugInAssemblies();
            List<IExport> plugins = GetPlugIns(pluginAssemblies);

            foreach (IExport exporter in plugins)
            {
                _converters.Add(exporter.ConverterType, exporter);
            }
        }
        private static List<Assembly> LoadPlugInAssemblies()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            FileInfo[] files = dInfo.GetFiles("*.dll");

            List<Assembly> plugInAssemblyList = new List<Assembly>();

            if (null != files)
            {
                foreach (FileInfo file in files)
                {
                    plugInAssemblyList.Add(Assembly.LoadFile(file.FullName));
                }
            }
            return plugInAssemblyList;
        }

        static List<IExport> GetPlugIns(List<Assembly> assemblies) { 
            List<Type> availableTypes = new List<Type>();

            foreach (Assembly currentAssembly in assemblies)
                availableTypes.AddRange(currentAssembly.GetTypes());

            // get a list of objects that implement the IExport interface AND 
            // have the ConverterPluginAttribute
            List<Type> converterList = availableTypes.FindAll(delegate (Type t)
            {
                List<Type> interfaceTypes = new List<Type>(t.GetInterfaces());
                var arr = t.GetCustomAttributes(typeof(ConverterPluginAttributes), true);
                
                return !(arr == null || arr.Length == 0) && interfaceTypes.Contains(typeof(IExport));
            });

            // convert the list of Objects to an instantiated list of IExports
            return converterList.ConvertAll(delegate (Type t) { return Activator.CreateInstance(t) as IExport; });
        }
    }
}
