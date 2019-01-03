using NUnit.Framework;
using TextDedup.Library.Command;
using TextDedup.Library.Dto;

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
            FetchData fd = new FetchData(args, null);

            Assert.IsTrue(fd.Execute() != null && fd.Status == FetchData.StatusEnum.Success);
        }

        [Test]
        public void NullOnMissingFile()
        {
            FetchData fd1 = new FetchData(new Args("Missing.txt", ";", "Test.txt"), null);
            FetchData fd2 = new FetchData(new Args("/fake/path.txt", ";", "Test.txt"), null);

            Assert.IsTrue(fd1.Execute() == null && fd1.Status == FetchData.StatusEnum.FileNotFound);
            Assert.IsTrue(fd2.Execute() == null && fd2.Status == FetchData.StatusEnum.FileNotFound);
        }
    }
}