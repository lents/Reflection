using Reflection;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly pluginAssembly = Assembly.LoadFrom("D:/Projects/OTUS/Reflection/Plugin/bin/Debug/net8.0/Plugin.dll");

            foreach (Type type in pluginAssembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                {
                    IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(type);

                    string pluginName = pluginInstance.GetName();
                    Console.WriteLine($"Loaded Plugin: {pluginName}");
                }
            }
        }
    }
}