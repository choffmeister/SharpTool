namespace SharpTool.Tools
{
    /// <summary>
    /// Base interface for all tools.
    /// </summary>
    public interface ITool
    {
        /// <summary>
        /// Executes the tool.
        /// </summary>
        /// <param name="console">The console.</param>
        /// <param name="config">The configuration provider.</param>
        /// <param name="projectDirectory">The project directory.</param>
        void Execute(IConsole console, IConfigurationProvider config, string projectDirectory);
    }
}
