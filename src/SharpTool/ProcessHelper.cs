using System.Diagnostics;
using System.IO;

namespace SharpTool
{
    /// <summary>
    /// Helper class that allows easy execution of subprocesses.
    /// </summary>
    public static class ProcessHelper
    {
        /// <summary>
        /// Executes a command and blocks until the subprocess has finished.
        /// </summary>
        /// <returns>The result object.</returns>
        /// <param name="console">The console.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="workingDirectory">The working directory.</param>
        public static Result Execute(IConsole console, string fileName, string arguments, string workingDirectory = null)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;

            if (workingDirectory != null)
            {
                psi.WorkingDirectory = workingDirectory;
            }

            StringWriter stdOut = new StringWriter();
            StringWriter stdError = new StringWriter();
            StringWriter combined = new StringWriter();

            using (Process p = new Process())
            {
                p.StartInfo = psi;
                p.Start();

                p.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    if (e.Data != null)
                    {
                        stdOut.WriteLine(e.Data);
                        console.WriteLine(e.Data);
                    }
                };
                p.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    if (e.Data != null)
                    {
                        stdError.WriteLine(e.Data);
                        console.WriteErrorLine(e.Data);
                    }
                };
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();

                return new Result(p.ExitCode, stdOut.ToString(), stdError.ToString(), combined.ToString());
            }
        }

        /// <summary>
        /// The result of an executed subprocess.
        /// </summary>
        public class Result
        {
            private readonly int exitCode;
            private readonly string stdOut;
            private readonly string stdError;
            private readonly string combined;

            /// <summary>
            /// Initializes a new instance of the <see cref="Result"/> class.
            /// </summary>
            /// <param name="exitCode">The exit code.</param>
            /// <param name="stdOut">The standard output.</param>
            /// <param name="stdError">The standard error.</param>
            /// <param name="combined">The combined standard output and error.</param>
            public Result(int exitCode, string stdOut, string stdError, string combined)
            {
                this.exitCode = exitCode;
                this.stdOut = stdOut;
                this.stdError = stdError;
                this.combined = combined;
            }

            /// <summary>
            /// Gets the exit code.
            /// </summary>
            /// <value>The exit code.</value>
            public int ExitCode
            {
                get { return this.exitCode; }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="SharpTool.ProcessHelper+Result"/> is success.
            /// </summary>
            /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
            public bool Success
            {
                get { return this.exitCode == 0; }
            }

            /// <summary>
            /// Gets the complete standard output.
            /// </summary>
            /// <value>The standard output.</value>
            public string StdOut
            {
                get { return this.stdOut; }
            }

            /// <summary>
            /// Gets the complete standard error.
            /// </summary>
            /// <value>The standard error.</value>
            public string StdError
            {
                get { return this.stdError; }
            }

            /// <summary>
            /// Gets the combined standard output and error.
            /// </summary>
            /// <value>The combined standard output and error.</value>
            public string Combined
            {
                get { return this.combined; }
            }
        }
    }
}
