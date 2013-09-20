using System;
using System.Runtime.InteropServices;

namespace SharpTool
{
    /// <summary>
    /// Environment information.
    /// </summary>
    public class EnvironmentInformation
    {
        private readonly string sharpToolDirectory;
        private readonly Version sharpToolVersion;
        private readonly string runtimeDirectory;
        private readonly Version runtimeVersion;
        private readonly string runtimeName;
        private readonly string operatingSystemName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpTool.EnvironmentInformation"/> class.
        /// </summary>
        /// <param name="sharpToolDirectory">The SharpTool directory.</param>
        public EnvironmentInformation(string sharpToolDirectory)
        {
            this.sharpToolDirectory = sharpToolDirectory;
            this.sharpToolVersion = this.GetType().Assembly.GetName().Version;
            this.runtimeDirectory = RuntimeEnvironment.GetRuntimeDirectory();
            this.runtimeVersion = Environment.Version;
            this.runtimeName = Type.GetType("Mono.Runtime") == null ? ".NET" : "Mono";
            this.operatingSystemName = Environment.OSVersion.VersionString;
        }

        /// <summary>
        /// Gets the SharpTool directory.
        /// </summary>
        /// <value>The SharpTool directory.</value>
        public string SharpToolDirectory
        {
            get { return this.sharpToolDirectory; }
        }

        /// <summary>
        /// Gets the SharpTool version.
        /// </summary>
        /// <value>The SharpTool version.</value>
        public Version SharpToolVersion
        {
            get { return this.sharpToolVersion; }
        }

        /// <summary>
        /// Gets the runtime directory.
        /// </summary>
        /// <value>The runtime directory.</value>
        public string RuntimeDirectory
        {
            get { return this.runtimeDirectory; }
        }

        /// <summary>
        /// Gets the runtime version.
        /// </summary>
        /// <value>The runtime version.</value>
        public Version RuntimeVersion
        {
            get { return this.runtimeVersion; }
        }

        /// <summary>
        /// Gets the name of the runtime which is either ".NET" or "Mono".
        /// </summary>
        /// <value>The name of the runtime.</value>
        public string RuntimeName
        {
            get { return this.runtimeName; }
        }

        /// <summary>
        /// Gets the name of the operating system.
        /// </summary>
        /// <value>The name of the operating system.</value>
        public string OperatingSystemName
        {
            get { return this.operatingSystemName; }
        }
    }
}
