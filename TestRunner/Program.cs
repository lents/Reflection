using System.Reflection;

namespace TestRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get all types in the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Iterate through each method of the type
                foreach (MethodInfo method in type.GetMethods())
                {
                    // Check if the method has the [Test] attribute
                    if (method.GetCustomAttribute(typeof(TestAttribute)) is TestAttribute)
                    {
                        Console.WriteLine($"Running {method.Name} in {type.Name}...");

                        try
                        {
                            // Create an instance of the class if it's not static
                            object instance = type.IsAbstract && type.IsSealed ? null : Activator.CreateInstance(type);

                            // Invoke the method
                            method.Invoke(instance, null);

                            Console.WriteLine($"Test {method.Name}: Passed");
                        }
                        catch (Exception ex)
                        {
                            // Handle test failures
                            Console.WriteLine($"Test {method.Name}: Failed - {ex.InnerException?.Message}");
                        }
                    }
                }
            }
        }
    }
}
