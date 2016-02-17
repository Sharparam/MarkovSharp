namespace Sharparam.MarkovSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Sentences : IList<Sentence>
    {
        private static readonly Regex SentenceRegex = new Regex(@".+?([\.?!]|$)", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private readonly List<Sentence> _sentences;

        public Sentences()
        {
            _sentences = new List<Sentence>();
        }

        public Sentences(string input) : this()
        {
            Process(input);
        }

        public int Count => _sentences.Count;

        public bool IsReadOnly => false;

        public Sentence this[int index]
        {
            get
            {
                return _sentences[index];
            }

            set
            {
                _sentences[index] = value;
            }
        }

        public IEnumerator<Sentence> GetEnumerator()
        {
            return _sentences.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_sentences).GetEnumerator();
        }

        public void Add(Sentence item)
        {
            _sentences.Add(item);
        }

        public void Clear()
        {
            _sentences.Clear();
        }

        public bool Contains(Sentence item)
        {
            return _sentences.Contains(item);
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            _sentences.CopyTo(array, arrayIndex);
        }

        public bool Remove(Sentence item)
        {
            return _sentences.Remove(item);
        }

        public int IndexOf(Sentence item)
        {
            return _sentences.IndexOf(item);
        }

        public void Insert(int index, Sentence item)
        {
            _sentences.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _sentences.RemoveAt(index);
        }

        public void Process(string input)
        {
            var matches = SentenceRegex.Matches(input);

            foreach (Match match in matches)
                Add(new Sentence(match.Value));
        }
    }
}
