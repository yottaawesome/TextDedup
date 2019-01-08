using NUnit.Framework;
using TextDedup.Library.Command;
using TextDedup.Library.Dto;
using TextDedup.Library.Error;

namespace Tests
{
    public class FetchDataTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void ReadTestData()
        {
            Args args = new Args("Test.txt", ";", "Test.txt");
            FetchData fd = new FetchData(args);

            Assert.IsTrue(fd.Execute() != null);
        }

        [Test]
        public void NullOnMissingFile()
        {
            FetchData fd1 = new FetchData(new Args("Missing.txt", ";", "Test.txt"));
            FetchData fd2 = new FetchData(new Args("/fake/path.txt", ";", "Test.txt"));

            Assert.Throws(typeof(CommandException), () => fd1.Execute());
            Assert.Throws(typeof(CommandException), () => fd2.Execute());
        }
    }
}