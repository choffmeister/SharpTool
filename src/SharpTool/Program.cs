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
            // load embedded libraries
            LibraryManager.LoadLibraries();

            // create console
            IConsole console = new DefaultConsole();

            // detect directories
            string sharpToolDirectory = GetSharpToolDirectory();
            string projectDirectory = GetProjectRootDirectory(Environment.CurrentDirectory);

            // create tool chain
            ToolChain toolChain = new ToolChain(console, sharpToolDirectory, projectDirectory);

            // execute tool and exit
            ExecuteAndReturnExitCode(console, toolChain.Execute);
        }

        /// <summary>
        /// Executes an action and then terminates the process with exit code
        /// either 0 or 1 if the invocation has thrown an exception.
        /// </summary>
        /// <param name="console">The console.</param>
        /// <param name="action">The action to execute.</param>
        public static void ExecuteAndReturnExitCode(IConsole console, Action action)
        {
            try
            {
                action();

                // if we get there return with OK exit code
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                console.WriteErrorLine("Error: {0}", ex.Message);

                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Gets the home directory of the current user.
        /// </summary>
        /// <returns>The home directory.</returns>
        public static string GetHomeDirectory()
        {
            // in older versions of Mono the UserProfile folder returns an empty string
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string personal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return !string.IsNullOrWhiteSpace(userProfile) ? userProfile : personal;
        }

        /// <summary>
        /// Gets the directory of SharpTool and ensures that it
        /// exists.
        /// </summary>
        /// <returns>The SharpTool directory.</returns>
        public static string GetSharpToolDirectory()
        {
            string home = GetHomeDirectory();
            string sharpToolDirectory = Path.Combine(home, ".sharptool");

            if (!Directory.Exists(sharpToolDirectory))
            {
                Directory.CreateDirectory(sharpToolDirectory);
            }

            return sharpToolDirectory;
        }

        /// <summary>
        /// Iterates the directory tree until it finds a directory
        /// containing a sharptool.yml file.
        /// </summary>
        /// <returns>The project root path.</returns>
        /// <param name="path">Path to start searching at.</param>
        public static string GetProjectRootDirectory(string path)
        {
            DirectoryInfo current = new DirectoryInfo(path);

            while (current != null)
            {
                if (File.Exists(Path.Combine(current.FullName, "sharptool.yml")))
                {
                    return current.FullName;
                }
                else
                {
                    current = Directory.GetParent(current.FullName);
                }
            }

            throw new InvalidOperationException();
        }
    }
}
