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
            ProcessArgs processArgs1 = new ProcessArgs(null, null);
            ProcessArgs processArgs2 = new ProcessArgs(new string[] { "blah" }, null);

            Assert.IsTrue(processArgs1.Execute() == null && processArgs1.Status == ProcessArgs.StatusEnum.NoArgsFound);
            Assert.IsTrue(processArgs2.Execute() == null && processArgs2.Status == ProcessArgs.StatusEnum.NoFileArgFound);
        }

        [Test]
        public void ArgsOnSuccess()
        {
            string filePath = ProcessArgs.FileSwitch + "Test.txt";
            string delim = ProcessArgs.DelimSwitch + "||";

            ProcessArgs processArgs = new ProcessArgs(new string[2] { filePath, delim }, null);
            Args args = processArgs.Execute();

            Assert.IsTrue(args != null && args.FilePath != null && args.Delimiter == "||" && processArgs.Status == ProcessArgs.StatusEnum.Success);
        }
    }
}