using System;
using System.Reflection;

namespace ObjectMapper
{
    public class ObjectMapper
    {
        // Generic method to map properties from a source object to a target object
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            TTarget target = new TTarget();
            Type sourceType = typeof(TSource);
            Type targetType = typeof(TTarget);

            // Iterate through each property in the source object
            foreach (PropertyInfo sourceProperty in sourceType.GetProperties())
            {
                // Find the corresponding property in the target object
                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);

                // If the property exists in the target and types match, copy the value
                if (targetProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType && targetProperty.CanWrite)
                {
                    object value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }
            return target;
        }
    }
}
