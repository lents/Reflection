namespace AccessType
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        private void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

}
