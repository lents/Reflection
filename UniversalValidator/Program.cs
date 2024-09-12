using System.Reflection;

namespace UniversalValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Retrieve all DTO types in the assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            var dtoTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("Dto"));

            foreach (var type in dtoTypes)
            {
                // Create an instance of each DTO
                object instance = Activator.CreateInstance(type);

                // Validate each property of the DTO
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.PropertyType == typeof(string))
                    {
                        string value = (string)property.GetValue(instance);
                        if (string.IsNullOrEmpty(value))
                        {
                            Console.WriteLine($"{type.Name}.{property.Name} is invalid: Value cannot be null or empty.");
                        }
                        else
                        {
                            Console.WriteLine($"{type.Name}.{property.Name} is valid.");
                        }
                    }
                }
            }
        }
    }
}
