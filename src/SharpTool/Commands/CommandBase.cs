using System;

namespace SharpTool.Commands
{
    /// <summary>
    /// Base class for all commands.
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// Gets or sets the environment information.
        /// </summary>
        /// <value>The environment information.</value>
        public EnvironmentInformation Environment { get; set; }

        /// <summary>
        /// Gets or sets the console.
        /// </summary>
        /// <value>The console.</value>
        public IConsole Console { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfigurationProvider Configuration { get; set; }

        /// <summary>
        /// Gets or sets the project directory.
        /// </summary>
        /// <value>The project directory.</value>
        public string ProjectDirectory { get; set; }
    }
}
