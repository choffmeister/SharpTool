using System;
using System.Reflection;

namespace SharpTool
{
    /// <summary>
    /// The main SharpTool class.
    /// </summary>
    public class Tool
    {
        private readonly IConsole console;
        private readonly string sharpToolDirectory;
        private readonly string workingDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpTool.Tool"/> class.
        /// </summary>
        /// <param name="console">The console to print at.</param>
        /// <param name="sharpToolDirectory">The SharpTool directory.</param>
        /// <param name="workingDirectory">The current working directory.</param>
        public Tool(IConsole console, string sharpToolDirectory, string workingDirectory)
        {
            this.console = console;
            this.sharpToolDirectory = sharpToolDirectory;
            this.workingDirectory = workingDirectory;
        }

        /// <summary>
        /// Executes the tool.
        /// </summary>
        public void Execute()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            this.console.WriteLine("SharpTool v{0}", assembly.GetName().Version);
            this.console.WriteLine("Working directory: {0}", this.sharpToolDirectory);
            this.console.WriteLine("SharpTool directory: {0}", this.workingDirectory);
        }
    }
}
