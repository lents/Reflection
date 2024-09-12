using Reflection;

namespace Plugin
{
    public class SamplePlugin : IPlugin
    {
        public string GetName()
        {
            return "Sample Plugin Loaded Dynamically!";
        }
    }
}
