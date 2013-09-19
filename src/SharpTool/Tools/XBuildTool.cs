using System.Diagnostics;

namespace SharpTool.Tools
{
    /// <summary>
    /// Tool that builds the project with XBuild.
    /// </summary>
    public class XBuildTool : ITool
    {
        /// <summary>
        /// Executes the tool.
        /// </summary>
        /// <param name="console">The console.</param>
        /// <param name="config">The configuration provider.</param> 
        /// <param name="projectDirectory">The project directory.</param>
        public void Execute(IConsole console, IConfigurationProvider config, string projectDirectory)
        {
            string solutionFilePath = config.Get("base.solution");
            string xbuildParameters = "/p:Configuration=Release " + solutionFilePath;

            ProcessHelper.Result result = ProcessHelper.Execute(console, "xbuild", xbuildParameters, projectDirectory);
            if (!result.Success)
            {
                throw new ToolUnsuccessfulException("Build failed");
            }
        }
    }
}
