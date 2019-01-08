using NUnit.Framework;
using TextDedup.Library.Command;
using TextDedup.Library.Dto;

namespace Tests
{
    public class ProcessArgsTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void NullAndEmptyArgs()
        {
            Assert.IsNull(new ProcessArgs(null).Execute());
            Assert.IsNull(new ProcessArgs(new string[] { "blah" }).Execute());
        }

        [Test]
        public void ArgsOnSuccess()
        {
            string filePath = ProcessArgs.FileSwitch + "Test.txt";
            string delim = ProcessArgs.DelimSwitch + "||";

            ProcessArgs processArgs = new ProcessArgs(new string[2] { filePath, delim });
            Args args = processArgs.Execute();

            Assert.IsTrue(args != null && args.FilePath != null && args.Delimiter == "||");
        }
    }
}