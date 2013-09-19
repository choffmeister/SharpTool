using System;

namespace SharpTool
{
    /// <summary>
    /// Provides access to the project configuration file.
    /// </summary>
    public interface IConfigurationProvider : IDisposable
    {
        /// <summary>
        /// Get the value by the specified name.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="name">The name.</param>
        /// <param name="throwIfNotExistent">If an exception should be raised in case
        /// that the given configuration value does not exist.</param>
        string Get(string name, bool throwIfNotExistent = true);

        /// <summary>
        /// Get the array value by the specified name.
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="name">The name.</param>
        /// <param name="throwIfNotExistent">If an exception should be raised in case
        /// that the given configuration value does not exist.</param>
        string[] GetArray(string name, bool throwIfNotExistent = true);
    }
}
