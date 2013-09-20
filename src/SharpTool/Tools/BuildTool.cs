using System.ComponentModel;

namespace SharpTool.Tools
{
    /// <summary>
    /// Tool that builds the project with XBuild.
    /// </summary>
    public class BuildTool : ToolBase
    {
        /// <summary>
        /// Executes the tool.
        /// </summary>
        public override void Execute()
        {
            string buildTool = this.Environment.RuntimeName != "Mono" ? "MSBuild.exe" : "xbuild";
            string solutionFilePath = this.Configuration.Get("base.solution");
            string xbuildParameters = string.Format("/verbosity:quiet /p:Configuration=Release {0}", solutionFilePath);

            try
            {
                ProcessHelper.Result result = ProcessHelper.Execute(this.Console, buildTool, xbuildParameters, this.ProjectDirectory);
            
                if (!result.Success)
                {
                    throw new ToolUnsuccessfulException("Build failed");
                }
            }
            catch (Win32Exception ex)
            {
                throw new ToolUnsuccessfulException(string.Format("Could not find build tool {0}", buildTool), ex);
            }
        }
    }
}
