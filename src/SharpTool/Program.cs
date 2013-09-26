using System;

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
        public void Run(string[] args)
        {
            // create console
            IConsole console = new DefaultConsole();

            // create tool chain
            SharpToolCommandManager commandManager = new SharpToolCommandManager(console);

            // execute tool and exit
            try
            {
                int exitCode = commandManager.Execute(args);

                Environment.Exit(exitCode);
            }
            catch (Exception ex)
            {
                console.WriteErrorLine("Error: {0} ({1})", ex.Message, ex.GetType().Name);
                console.WriteErrorLine(ex.StackTrace.ToString());

                Environment.Exit(1);
            }
        }
    }
}
