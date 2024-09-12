namespace UniversalConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an object to convert
            SourceDto source = new SourceDto { Name = "Alice", Age = 28, Email = "alice@example.com" };

            // Convert the object to a string
            string serialized = UniversalConverter.ConvertToString(source);
            Console.WriteLine($"Serialized: {serialized}");

            // Convert the string back to an object
            SourceDto deserialized = UniversalConverter.ConvertFromString<SourceDto>(serialized);
            Console.WriteLine($"Deserialized: Name={deserialized.Name}, Age={deserialized.Age}, Email={deserialized.Email}");

        }
    }
}
