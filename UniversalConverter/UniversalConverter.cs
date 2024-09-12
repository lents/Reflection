namespace UniversalConverter
{
    public class UniversalConverter
    {
        // Convert an object to a string representation
        public static string ConvertToString(object obj)
        {
            Type type = obj.GetType();
            var propertyValues = type.GetProperties()
                                     .Select(p => $"{p.Name}={p.GetValue(obj)}")
                                     .ToList();

            return string.Join(", ", propertyValues);
        }

        // Convert a string representation back to an object of type T
        public static T ConvertFromString<T>(string data) where T : new()
        {
            T obj = new T();
            Type type = typeof(T);
            var properties = type.GetProperties();

            // Parse the string data into key-value pairs
            var keyValuePairs = data.Split(',').Select(part => part.Split('=')).ToDictionary(s => s[0].Trim(), s => s[1].Trim());

            foreach (var property in properties)
            {
                if (keyValuePairs.ContainsKey(property.Name))
                {
                    // Convert the string value to the appropriate type and set it to the property
                    object value = Convert.ChangeType(keyValuePairs[property.Name], property.PropertyType);
                    property.SetValue(obj, value);
                }
            }

            return obj;
        }
    }
}
