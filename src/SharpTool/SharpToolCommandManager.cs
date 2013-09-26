using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DotArguments;
using SharpTool.Commands;

namespace SharpTool
{
    /// <summary>
    /// The main SharpTool class.
    /// </summary>
    public class SharpToolCommandManager : CommandManager
    {
        private readonly EnvironmentInformation environment;
        private readonly IConsole console;
        private readonly string sharpToolDirectory;
        private readonly string projectDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpToolCommandManager"/> class.
        /// </summary>
        /// <param name="console">The console to print at.</param>
        public SharpToolCommandManager(IConsole console)
            : base(new GNUArgumentParser())
        {
            this.console = console;
            this.sharpToolDirectory = DirectoryHelper.GetSharpToolDirectory();
            this.projectDirectory = DirectoryHelper.GetProjectRootDirectory(Environment.CurrentDirectory);
            this.environment = new EnvironmentInformation(this.sharpToolDirectory);

            this.RegisterAllCommands();
        }

        /// <summary>
        /// Initializes a command before it is executed.
        /// </summary>
        /// <param name="command">The command.</param>
        protected override void InitializeCommand(ICommand command)
        {
            string sharpToolFilePath = Path.Combine(this.projectDirectory, "sharptool.yml");
            IConfigurationProvider configuration = new YamlConfigurationProvider(sharpToolFilePath);

            CommandBase castedCommand = command as CommandBase;
            if (castedCommand != null)
            {
                castedCommand.Environment = this.environment;
                castedCommand.Console = this.console;
                castedCommand.Configuration = configuration;
                castedCommand.ProjectDirectory = this.projectDirectory;
            }
        }

        private void RegisterAllCommands()
        {
            var commandTypes = Assembly.GetEntryAssembly().GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t));

            foreach (Type commandType in commandTypes)
            {
                this.RegisterCommand(commandType);
            }
        }
    }
}
