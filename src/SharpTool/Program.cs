using System;
using System.IO;

namespace SharpTool
{
    /// <summary>
    /// Executable main entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            // create console
            IConsole console = new DefaultConsole();

            // detect directories
            string sharpToolDirectory = GetSharpToolDirectory();
            string workingDirectory = Environment.CurrentDirectory;

            // create tool
            Tool tool = new Tool(console, sharpToolDirectory, workingDirectory);

            // execute tool and exit
            ExecuteAndReturnExitCode(console, tool.Execute);
        }

        /// <summary>
        /// Executes an action and then terminates the process with exit code
        /// either 0 or 1 if the invocation has thrown an exception.
        /// </summary>
        /// <param name="console">The console.</param>
        /// <param name="action">The action to execute.</param>
        private static void ExecuteAndReturnExitCode(IConsole console, Action action)
        {
            try
            {
                action();

                // if we get there return with OK exit code
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                console.WriteErrorLine(ex.Message);

                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Gets the directory of SharpTool and ensures that it
        /// exists.
        /// </summary>
        /// <returns>The SharpTool directory.</returns>
        private static string GetSharpToolDirectory()
        {
            // in older versions of Mono the UserProfile folder returns an empty string
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string personal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string home = !string.IsNullOrWhiteSpace(userProfile) ? userProfile : personal;

            string sharpToolDirectory = Path.Combine(home, ".sharptool");

            if (!Directory.Exists(sharpToolDirectory))
            {
                Directory.CreateDirectory(sharpToolDirectory);
            }

            return sharpToolDirectory;
        }
    }
}
