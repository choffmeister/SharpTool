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
        private readonly string projectDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpTool.Tool"/> class.
        /// </summary>
        /// <param name="console">The console to print at.</param>
        /// <param name="sharpToolDirectory">The SharpTool directory.</param>
        /// <param name="projectDirectory">The project root directory.</param>
        public Tool(IConsole console, string sharpToolDirectory, string projectDirectory)
        {
            this.console = console;
            this.sharpToolDirectory = sharpToolDirectory;
            this.projectDirectory = projectDirectory;
        }

        /// <summary>
        /// Executes the tool.
        /// </summary>
        public void Execute()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            this.console.WriteLine("SharpTool v{0}", assembly.GetName().Version);
            this.console.WriteLine("SharpTool directory: {0}", this.sharpToolDirectory);
            this.console.WriteLine("Project directory: {0}", this.projectDirectory);
        }
    }
}
