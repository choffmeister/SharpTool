using System;
using System.Globalization;
using System.Linq;

namespace SharpTool
{
    /// <summary>
    /// Extension methods for <see cref="IConfigurationProvider"/> implementations.
    /// </summary>
    public static class ConfigurationProviderExtensions
    {
        /// <summary>
        /// Get the value by the specified name with given type.
        /// </summary>
        /// <returns>The converted value.</returns>
        /// <param name="config">The configuration provider.</param>
        /// <param name="name">The name.</param>
        /// <param name="throwIfNotExistent">If an exception should be raised in case
        /// that the given configuration value does not exist.</param>
        /// <typeparam name="T">The target type of the value.</typeparam>
        public static T Get<T>(this IConfigurationProvider config, string name, bool throwIfNotExistent = true)
        {
            string stringValue = config.Get(name, throwIfNotExistent);

            if (stringValue != null)
            {
                return ConvertString<T>(stringValue);
            }

            return default(T);
        }

        /// <summary>
        /// Get the array value by the specified name with given type.
        /// </summary>
        /// <returns>The array with the converted value.</returns>
        /// <param name="config">The configuration provider.</param>
        /// <param name="name">The name.</param>
        /// <param name="throwIfNotExistent">If an exception should be raised in case
        /// that the given configuration value does not exist.</param>
        /// <typeparam name="T">The target type of the value.</typeparam>
        public static T[] GetArray<T>(this IConfigurationProvider config, string name, bool throwIfNotExistent = true)
        {
            string[] stringValues = config.GetArray(name, throwIfNotExistent);

            if (stringValues != null)
            {
                return stringValues.Select(ConvertString<T>).ToArray();
            }

            return null;
        }

        /// <summary>
        /// Converts a string into another type.
        /// </summary>
        /// <returns>The converted value.</returns>
        /// <param name="value">The string value.</param>
        /// <typeparam name="T">The target type of the value.</typeparam>
        private static T ConvertString<T>(string value)
        {
            if (value != null)
            {
                Type type = typeof(T);
                IFormatProvider format = CultureInfo.InvariantCulture;

                return (T)Convert.ChangeType(value, type, format);
            }

            return default(T);
        }
    }
}
