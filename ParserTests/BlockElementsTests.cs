using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserTests
{
    public class TestBase
    {
        protected ScrewTurnParser ScrewTurn = new ScrewTurnParser();
    }

    [TestClass]
    public class Headings : TestBase
    {
        [TestMethod]
        public void Heading1()
        {
            var input = "==Header 1==";
            var expected = "# Header 1";

            var actual = ScrewTurn.ToMarkdown(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Heading2()
        {
            var input = "===Header 2===";
            var expected = "## Header 2";

            var actual = ScrewTurn.ToMarkdown(input);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Heading3()
        {
            var input = "====Header 3====";
            var expected = "### Header 3";

            var actual = ScrewTurn.ToMarkdown(input);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Heading4()
        {
            var input = "=====Header 4=====";
            var expected = "#### Header 4";

            var actual = ScrewTurn.ToMarkdown(input);
            
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

            var actual = ScrewTurn.ToMarkdown(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderedList()
        {
            var input = "# List item\n# List item";
            var expected = "1. List item\n2. List item";

            var actual = ScrewTurn.ToMarkdown(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedUnorderedList()
        {
            var input = "* List item 1\n** List item 11\n** List item 12\n * List item 2";
            var expected = "* List item 1\n    * List item 11\n    * List item 12\n* List item 2";

            var actual = ScrewTurn.ToMarkdown(input);

            Assert.AreEqual(expected, actual);
        }

    }

}
