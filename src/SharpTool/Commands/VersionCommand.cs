using DotArguments;

namespace SharpTool.Commands
{
    /// <summary>
    /// Version command.
    /// </summary>
    [Command("version")]
    public class VersionCommand : CommandBase, ICommand
    {
        /// <summary>
        /// Execute this instance.
        /// </summary>
        /// <returns>The exit code.</returns>
        public int Execute()
        {
            this.Console.WriteLine("SharpTool Version: {0}", this.Environment.SharpToolVersion);
            this.Console.WriteLine("       OS Version: {0}", this.Environment.OperatingSystemName);
            this.Console.WriteLine("      CLR Version: {0} {1}", this.Environment.RuntimeName, this.Environment.RuntimeVersion);

            return 0;
        }
    }
}
