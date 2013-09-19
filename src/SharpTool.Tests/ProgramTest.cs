using System;
using System.IO;
using NUnit.Framework;

namespace SharpTool.Tests
{
    /// <summary>
    /// Tests for the <see cref="Program"/> class.
    /// </summary>
    [TestFixture]
    public class ProgramTest
    {
        private string tempFolder;

        /// <summary>
        /// Creates a new temporary folder for each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(this.tempFolder);
        }

        /// <summary>
        /// Clears up the temporary folder after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (this.tempFolder != null && Directory.Exists(this.tempFolder))
            {
                Directory.Delete(this.tempFolder, true);
                this.tempFolder = null;
            }
        }

        /// <summary>
        /// Tests if the project root is found properly.
        /// </summary>
        [Test]
        public void TestGetProjectRootDirectory1()
        {
            string sub1 = Path.Combine(this.tempFolder, "sub1");
            string sub2 = Path.Combine(sub1, "sub2");
            string sub3 = Path.Combine(sub2, "sub3");

            Directory.CreateDirectory(sub1);
            Directory.CreateDirectory(sub2);
            Directory.CreateDirectory(sub3);

            File.WriteAllText(Path.Combine(sub2, "sharptool.yml"), "config");

            Assert.AreEqual(sub2, Program.GetProjectRootDirectory(sub3));
        }

        /// <summary>
        /// Tests if a exception is raised, if no sharptool.yml file can
        /// be found in any of the parent directories.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetProjectRootDirectory2()
        {
            string sub1 = Path.Combine(this.tempFolder, "sub1");
            string sub2 = Path.Combine(sub1, "sub2");
            string sub3 = Path.Combine(sub2, "sub3");

            Directory.CreateDirectory(sub1);
            Directory.CreateDirectory(sub2);
            Directory.CreateDirectory(sub3);

            Program.GetProjectRootDirectory(sub3);
        }

        /// <summary>
        /// Tests if the home directory is located properly.
        /// </summary>
        [Test]
        public void GetHomeDirectory()
        {
            string homeDirectory = Program.GetHomeDirectory();

            Assert.IsNotNull(homeDirectory);
            Assert.IsNotEmpty(homeDirectory);
            Assert.IsTrue(Directory.Exists(homeDirectory));
        }
    }
}
