using DemoSourceLink;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace DemoSourceLinkRegex
{
    public class TextCalculatorRegex : TextCalculatorBase
    {
        public TextCalculatorRegex(ILogger<TextCalculatorRegex> logger) : base(logger)
        {
        }

        private static readonly Regex _reWordCounter = new Regex(@"\w+");
        private static readonly Regex _reSentenceCounter = new Regex(@"\.+");
        private static readonly Regex _reParagraphCounter = new Regex(@"[\r\n]+");

        protected override TextStats CalculateStatsCore(string document)
        {
            int charCount = CalculateCharCount(document);
            int wordCount = 1 + _reWordCounter.Matches(document).Count;
            int sentenceCount = 1 + _reSentenceCounter.Matches(document).Count;
            int paragraphCount = 1 + _reParagraphCounter.Matches(document).Count;

            return new TextStats(charCount, wordCount, sentenceCount, paragraphCount);
        }

        private int CalculateCharCount(string document) => document.Length;
    }
}
