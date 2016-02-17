namespace Sharparam.MarkovSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Humanizer;

    public class Sentence : IEnumerable<Word>
    {
        private readonly List<Word> _words = new List<Word>(); 

        public Sentence(string source)
        {
            Source = Fix(source);

            foreach (Match match in Common.WordRegex.Matches(Source))
            {
                _words.Add(new Word(match.Groups[1].Value));
            }
        }

        public string Source { get; }

        /// <summary>
        /// Cleans up a string in a format suitable for parsing.
        /// </summary>
        /// <param name="content">Text to fix.</param>
        /// <returns>Fixed text.</returns>
        public static string Fix(string content)
        {
            string result = content.Trim().Transform(To.SentenceCase);

            if (!Common.PunctuationRegex.IsMatch(result))
                result += '.';

            return result;
        }

        public IEnumerator<Word> GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        public override string ToString()
        {
            return Source;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_words).GetEnumerator();
        }
    }
}
