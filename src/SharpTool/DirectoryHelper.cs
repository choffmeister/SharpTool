using System;
using System.IO;

namespace SharpTool
{
    /// <summary>
    /// Directory helper.
    /// </summary>
    public static class DirectoryHelper
    {
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
