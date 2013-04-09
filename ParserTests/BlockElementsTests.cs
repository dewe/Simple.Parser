using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserTests
{
    public class TestBase
    {
        protected ScrewturnToMarkupParser s2md = new ScrewturnToMarkupParser();
    }

    [TestClass]
    public class Headings : TestBase
    {
        [TestMethod]
        public void Heading1()
        {
            var input = "==Header 1==";
            var expected = "# Header 1";

            var actual = s2md.Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Heading2()
        {
            var input = "===Header 2===";
            var expected = "## Header 2";

            var actual = s2md.Transform(input);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Heading3()
        {
            var input = "====Header 3====";
            var expected = "### Header 3";

            var actual = s2md.Transform(input);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Heading4()
        {
            var input = "=====Header 4=====";
            var expected = "#### Header 4";

            var actual = s2md.Transform(input);
            
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class Lists : TestBase
    {
        [TestMethod]
        public void UnorderedList()
        {
            var input = "* List item\n* List item";
            var expected = "* List item\n* List item";

            var actual = s2md.Transform(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderedList()
        {
            var input = "# List item\n# List item";
            var expected = "1. List item\n2. List item";

            var actual = s2md.Transform(input);

            Assert.AreEqual(expected, actual);
        }
    }

}
