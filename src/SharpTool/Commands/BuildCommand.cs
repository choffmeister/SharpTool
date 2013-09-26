using DotArguments;

namespace SharpTool.Commands
{
    /// <summary>
    /// Build command.
    /// </summary>
    [Command("build")]
    public class BuildCommand : CommandBase, ICommand
    {
        /// <summary>
        /// Execute this instance.
        /// </summary>
        /// <returns>The exit code.</returns>
        public int Execute()
        {
            Console.Write("BUILD\n");
            return 0;
        }
    }
}
