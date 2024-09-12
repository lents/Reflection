namespace TestRunner
{
    // Sample class with test methods
    public class MathTests
    {
        [Test]
        public void AddTest()
        {
            int result = 2 + 2;
            if (result != 4)
            {
                throw new Exception("AddTest failed");
            }
        }

        [Test]
        public void MultiplyTest()
        {
            int result = 3 * 3;
            if (result != 9)
            {
                throw new Exception("MultiplyTest failed");
            }
        }
    }

    // Another sample class with test methods
    public class StringTests
    {
        [Test]
        public void ConcatTest()
        {
            string result = "Hello" + " World";
            if (result != "Hello World")
            {
                throw new Exception("ConcatTest failed");
            }
        }
    }

}
