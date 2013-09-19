using System;

namespace SharpTool
{
    /// <summary>
    /// Interface for an output-only console.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Write to console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        void Write(string fmt, params object[] args);

        /// <summary>
        /// Write line to console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        void WriteLine(string fmt, params object[] args);

        /// <summary>
        /// Write to error console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        void WriteError(string fmt, params object[] args);

        /// <summary>
        /// Write line to error console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        void WriteErrorLine(string fmt, params object[] args);
    }
}
