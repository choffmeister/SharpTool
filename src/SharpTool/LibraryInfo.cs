using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SharpTool
{
    /// <summary>
    /// Meta information for an embedded third-party library.
    /// </summary>
    public class LibraryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryInfo"/> class.
        /// </summary>
        /// <param name="assembly">The containing assembly.</param>
        /// <param name="identifier">The identifier.</param>
        public LibraryInfo(Assembly assembly, string identifier)
        {
            using (StreamReader infoReader = new StreamReader(assembly.GetManifestResourceStream("Libraries/" + identifier + "/INFO")))
            using (StreamReader licenseReader = new StreamReader(assembly.GetManifestResourceStream("Libraries/" + identifier + "/LICENSE")))
            {
                string[] infos = infoReader.ReadToEnd().Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                string license = licenseReader.ReadToEnd();

                this.Identifier = identifier;
                this.Name = infos.Single(n => n.StartsWith("Name: ")).Substring("Name: ".Length);
                this.Version = infos.Single(n => n.StartsWith("Version: ")).Substring("Version: ".Length);
                this.Url = infos.Single(n => n.StartsWith("Url: ")).Substring("Url: ".Length);
                this.License = license;
                this.Assemblies = assembly.GetManifestResourceNames()
                    .Where(n => n.StartsWith("Libraries/" + identifier + "/"))
                    .Where(n => n.EndsWith(".dll"))
                    .Select(n => n.Substring(("Libraries/" + identifier + "/").Length))
                    .ToArray();
            }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the license.
        /// </summary>
        /// <value>The license.</value>
        public string License { get; set; }

        /// <summary>
        /// Gets or sets the assembly names.
        /// </summary>
        /// <value>The assembly names.</value>
        public string[] Assemblies { get; set; }
    }
}
