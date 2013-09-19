using System;
using System.IO;
using System.Linq;
using YamlDotNet.RepresentationModel;

namespace SharpTool
{
    /// <summary>
    /// Configuration provider that uses a YAML file as source.
    /// </summary>
    public class YamlConfigurationProvider : IConfigurationProvider
    {
        private readonly string path;
        private readonly YamlMappingNode yaml;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpTool.YamlConfigurationProvider"/> class.
        /// </summary>
        /// <param name="path">The path to the YAML file.</param>
        public YamlConfigurationProvider(string path)
        {
            this.path = path;
            this.yaml = ParseYaml(this.path);
        }

        /// <summary>
        /// Get the value by the specified name.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="name">The name.</param>
        /// <param name="throwIfNotExistent">If an exception should be raised in case
        /// that the given configuration value does not exist.</param>
        public string Get(string name, bool throwIfNotExistent = true)
        {
            YamlScalarNode node = (YamlScalarNode)Traverse(this.yaml, name);

            return node.Value;
        }

        /// <summary>
        /// Get the array value by the specified name.
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="name">The name.</param>
        /// <param name="throwIfNotExistent">If an exception should be raised in case
        /// that the given configuration value does not exist.</param>
        public string[] GetArray(string name, bool throwIfNotExistent = true)
        {
            YamlSequenceNode node = (YamlSequenceNode)Traverse(this.yaml, name);

            return node.Children
                .Select(n => ((YamlScalarNode)n).Value)
                .ToArray();
        }

        /// <summary>
        /// Releases all resource used by the <see cref="SharpTool.YamlConfigurationProvider"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="SharpTool.YamlConfigurationProvider"/>. The <see cref="Dispose"/> method leaves the
        /// <see cref="SharpTool.YamlConfigurationProvider"/> in an unusable state. After calling <see cref="Dispose"/>,
        /// you must release all references to the <see cref="SharpTool.YamlConfigurationProvider"/> so the garbage
        /// collector can reclaim the memory that the <see cref="SharpTool.YamlConfigurationProvider"/> was occupying.</remarks>
        public void Dispose()
        {
        }

        private static YamlNode Traverse(YamlNode current, string name)
        {
            string[] parts = name.Split(new char[] { '.' }, StringSplitOptions.None);

            foreach (string part in parts)
            {
                current = ((YamlMappingNode)current).Children[new YamlScalarNode(part)];
            }

            return current;
        }

        private static YamlMappingNode ParseYaml(string path)
        {
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var fileReader = new StreamReader(file))
            {
                YamlStream yaml = new YamlStream();
                yaml.Load(fileReader);

                return (YamlMappingNode)yaml.Documents[0].RootNode;
            }
        }
    }
}
