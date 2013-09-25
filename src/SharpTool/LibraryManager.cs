using System.IO;
using System.Linq;
using System.Reflection;

namespace SharpTool
{
    /// <summary>
    /// Manages embedded third-party libraries.
    /// </summary>
    public class LibraryManager
    {
        private static readonly Assembly EntryAssembly = Assembly.GetEntryAssembly();
        private static LibraryInfo[] libraries;

        /// <summary>
        /// Gets the list of all embedded libraries.
        /// </summary>
        /// <value>The embedded libraries.</value>
        public static LibraryInfo[] Libraries
        {
            get { return libraries; }
        }

        /// <summary>
        /// Loads all embedded libraries.
        /// </summary>
        public static void LoadLibraries()
        {
            libraries = ListLibraries();

            foreach (LibraryInfo library in libraries)
            {
                foreach (string assemblyName in library.Assemblies)
                {
                    string resourceName = string.Format("Libraries/{0}/{1}", library.Identifier, assemblyName);

                    LoadLibrary(resourceName);
                }
            }
        }

        private static LibraryInfo[] ListLibraries()
        {
            return EntryAssembly.GetManifestResourceNames()
                .Where(n => n.StartsWith("Libraries/"))
                .Select(n => n.Substring("Libraries/".Length))
                .Select(n => n.Split(new char[] { '/' }).First())
                .Distinct()
                .Select(n => new LibraryInfo(EntryAssembly, n))
                .ToArray();
        }

        private static void LoadLibrary(string manifestResourceName)
        {
            using (Stream stream = EntryAssembly.GetManifestResourceStream(manifestResourceName))
            {
                int size = (int)stream.Length;
                byte[] buffer = new byte[size];
                stream.Read(buffer, 0, size);

                Assembly.Load(buffer);
            }
        }
    }
}
