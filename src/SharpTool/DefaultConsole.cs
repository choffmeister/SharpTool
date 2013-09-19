using System;

namespace SharpTool
{
    /// <summary>
    /// Abstraction layer above the ordinary <see cref="Console"/> class.
    /// </summary>
    public class DefaultConsole : IConsole
    {
        /// <summary>
        /// Write to console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        public void Write(string fmt, params object[] args)
        {
            Console.Write(string.Format(fmt, args));
        }

        /// <summary>
        /// Write line to console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        public void WriteLine(string fmt, params object[] args)
        {
            Console.WriteLine(string.Format(fmt, args));
        }

        /// <summary>
        /// Write to error console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        public void WriteError(string fmt, params object[] args)
        {
            Console.Error.Write(string.Format(fmt, args));
        }

        /// <summary>
        /// Write line to error console.
        /// </summary>
        /// <param name="fmt">The format string.</param>
        /// <param name="args">The arguments to inject into the format string.</param>
        public void WriteErrorLine(string fmt, params object[] args)
        {
            Console.Error.WriteLine(string.Format(fmt, args));
        }
    }
}
