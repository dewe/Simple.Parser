using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace ParserTests
{
    [TestClass]
    public class Headings
    {
        private ScrewturnToMarkupParser s2md = new ScrewturnToMarkupParser();

        [TestMethod]
        public void Heading1()
        {
            var input = "==Header1==";
            var expected = "# Header1";

            var actual = s2md.Transform(input);
            Assert.AreEqual(actual, expected);
        }
    }

    public class ScrewturnToMarkupParser
    {

        public string Transform(string input)
        {
            return ReplaceHeaders(input);
        }

        private static string ReplaceHeaders(string input)
        {
            var h1 = new Regex(@"^==(.+?)==\n?", RegexOptions.Compiled | RegexOptions.Multiline);

            return h1.Replace(input, new MatchEvaluator(
                (m) =>
                {
                    var header = m.Groups[1].ToString();
                    return "# " + header;
                }
            ));
        }


    }
}
