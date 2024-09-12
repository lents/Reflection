namespace ObjectMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a source object with some data
            SourceDto source = new SourceDto
            {
                Name = "John Doe",
                Age = 30,
                Email = "john.doe@example.com"
            };

            // Use the ObjectMapper to map to the target entity
            TargetEntity target = ObjectMapper.Map<SourceDto, TargetEntity>(source);

            // Display the mapped values
            Console.WriteLine($"Name: {target.Name}, Age: {target.Age}, Email: {target.Email}");

        }
    }
}
