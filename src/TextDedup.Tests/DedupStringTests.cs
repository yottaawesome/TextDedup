using NUnit.Framework;
using Commands = TextDedup.Library.Command;

namespace Tests
{
    public class DedupStringTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void One()
        {
            string str = "one;";
            string delim = ";";

            var dds = new Commands.DedupString(str, delim);
            Assert.IsTrue(dds.Execute() == "one");
        }

        [Test]
        public void OneOne()
        {
            string str = "one;one";
            string delim = ";";

            var dds = new Commands.DedupString(str, delim);
            Assert.IsTrue(dds.Execute() == "one");
        }

        [Test]
        public void OneTwoOne()
        {
            string str = "one;two;one";
            string delim = ";";

            var dds = new Commands.DedupString(str, delim);
            Assert.IsTrue(dds.Execute() == "one;two");
        }
    }
}