using System.Reflection;

namespace AccessType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccessProperties();

            AccessMethods();

            AccessFields();
        }

        static void AccessProperties() {
            Person person = new Person { FirstName = "John", LastName = "Doe" };

            Type type = person.GetType();

            PropertyInfo[] properties = type.GetProperties();
            Console.WriteLine("Public Properties:");
            foreach (var property in properties)
            {
                Console.WriteLine($"Property: {property.Name}, Value: {property.GetValue(person)}");
            }

            // Access a private property using BindingFlags
            PropertyInfo privateProperty = type.GetProperty("Age", BindingFlags.NonPublic | BindingFlags.Instance);
            privateProperty.SetValue(person, 30); // Set the value of the private property
            Console.WriteLine($"Private Property 'Age': {privateProperty.GetValue(person)}");
        }

        static void AccessMethods() {
            Calculator calc = new Calculator();

            Type type = calc.GetType();

            MethodInfo addMethod = type.GetMethod("Add");
            int result = (int)addMethod.Invoke(calc, new object[] { 5, 10 });
            Console.WriteLine($"Add Method Result: {result}"); // Output: 15

            // Access and invoke a private method
            MethodInfo logMethod = type.GetMethod("Log", BindingFlags.NonPublic | BindingFlags.Instance);
            logMethod.Invoke(calc, new object[] { "Reflection is powerful!" });
        }

        static void AccessFields() {
            Configuration config = new Configuration();

            Type type = config.GetType();

            FieldInfo publicField = type.GetField("AppName");
            Console.WriteLine($"Public Field - AppName: {publicField.GetValue(config)}");

            // Access and modify a private field
            FieldInfo privateField = type.GetField("maxUsers", BindingFlags.NonPublic | BindingFlags.Instance);
            privateField.SetValue(config, 200);
            Console.WriteLine($"Private Field - maxUsers: {privateField.GetValue(config)}");
        }
    }
}
