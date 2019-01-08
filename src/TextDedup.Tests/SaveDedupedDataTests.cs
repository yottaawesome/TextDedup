using NUnit.Framework;
using System.IO;
using Commands = TextDedup.Library.Command;

namespace Tests
{
    public class SaveDedupedDataTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Save()
        {
            string fileName = "SaveDedupStringUnitTest.txt";
            var save = new Commands.SaveDedupedData(fileName, "blah");
            save.Execute();
            Assert.IsTrue(File.Exists(fileName));
        }
    }
}