using System;
using System.IO;
using SharpTool.Tools;

namespace SharpTool
{
    /// <summary>
    /// The main SharpTool class.
    /// </summary>
    public class ToolChain
    {
        private readonly IConsole console;
        private readonly string sharpToolDirectory;
        private readonly string projectDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpTool.ToolChain"/> class.
        /// </summary>
        /// <param name="console">The console to print at.</param>
        /// <param name="sharpToolDirectory">The SharpTool directory.</param>
        /// <param name="projectDirectory">The project root directory.</param>
        public ToolChain(IConsole console, string sharpToolDirectory, string projectDirectory)
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
            EnvironmentInformation environment = new EnvironmentInformation(this.sharpToolDirectory);
            this.console.WriteLine("SharpTool Version: {0}", environment.SharpToolVersion);
            this.console.WriteLine("       OS Version: {0}", environment.OperatingSystemName);
            this.console.WriteLine("      CLR Version: {0} {1}", environment.RuntimeName, environment.RuntimeVersion);

            string sharpToolFilePath = Path.Combine(this.projectDirectory, "sharptool.yml");
            IConfigurationProvider configuration = new YamlConfigurationProvider(sharpToolFilePath);

            ToolBase tool = new BuildTool();
            tool.Environment = environment;
            tool.Console = this.console;
            tool.Configuration = configuration;
            tool.ProjectDirectory = this.projectDirectory;
            tool.Execute();
        }
    }
}
