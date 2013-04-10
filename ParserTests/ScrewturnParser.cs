using System.Text.RegularExpressions;

namespace ParserTests
{
    public class ScrewTurnParser
    {

        public string ToMarkdown(string input)
        {
            var text = input;

            text = FixLists(text);
            text = FixHeaders(text);

            return text;
        }

        private string FixLists(string input)
        {
            var ol = new Regex(@"(?<ol>#.+?)((?=\n\n)|$)", RegexOptions.Compiled | RegexOptions.Singleline);
            return ol.Replace(input, OrderedListEvaluator);
        }

        private string OrderedListEvaluator(Match match)
        {
            var li = new Regex(@"(?<=(?:^|\n))(#+)\s*(?<li>.+?)(?=(\n#)|$)", RegexOptions.Compiled | RegexOptions.Singleline);
            var list = match.Groups["ol"].Value;
            var count = 0;

            return li.Replace(list, m => { return string.Format("{0}. {1}", ++count, m.Groups["li"]); });
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