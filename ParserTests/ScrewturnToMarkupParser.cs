using System.Text.RegularExpressions;

namespace ParserTests
{
    public class ScrewturnToMarkupParser
    {

        public string Transform(string input)
        {
            var text = input;

            text = FixHeaders(text);
            text = FixLists(text);

            return text;
        }

        private string FixLists(string input)
        {
//            var olist = new Regex(@"(?<=(\n|^))((\*|\#)+(\ )?.+?\n)+((?=\n)|\z)", RegexOptions.Compiled | RegexOptions.Singleline);
            var olist = new Regex(@"^(\*|\#)+(\ )?(.+)?\n", RegexOptions.Compiled | RegexOptions.Singleline);

            //            text = olist.Replace(text, match =>
            return olist.Replace(input, new MatchEvaluator(
                        (m) =>
                        {
                            var item = m.Groups[0];
                            return "1. " + item;
                        }));
        }

        private string FixHeaders(string input)
        {
            var h1 = new Regex(@"^==(.+?)==\n?", RegexOptions.Compiled | RegexOptions.Multiline);
            var h2 = new Regex(@"^===(.+?)===\n?", RegexOptions.Compiled | RegexOptions.Multiline);
            var h3 = new Regex(@"^====(.+?)====\n?", RegexOptions.Compiled | RegexOptions.Multiline);
            var h4 = new Regex(@"^=====(.+?)=====\n?", RegexOptions.Compiled | RegexOptions.Multiline);

            var text = input;

            text = h4.Replace(text, new MatchEvaluator(
                (m) =>
                {
                    var header = m.Groups[1].ToString();
                    return "#### " + header;
                }));

            text = h3.Replace(text, new MatchEvaluator(
                (m) =>
                {
                    var header = m.Groups[1].ToString();
                    return "### " + header;
                }));

            text = h2.Replace(text, new MatchEvaluator(
                (m) =>
                {
                    var header = m.Groups[1].ToString();
                    return "## " + header;
                }));

            text = h1.Replace(text, new MatchEvaluator(
                (m) =>
                {
                    var header = m.Groups[1].ToString();
                    return "# " + header;
                }));


            return text;
        }


    }
}