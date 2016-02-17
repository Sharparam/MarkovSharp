namespace Sharparam.MarkovSharp
{
    using System.Collections.Generic;
    using System.Linq;

    public class WordData
    {
        private readonly Dictionary<Word, int> _successors = new Dictionary<Word, int>();

        public WordData(string word)
        {
            Word = new Word(word);
        }

        public WordData(Word word) : this(word.Content)
        {

        }

        public Word Word { get; }

        public int SuccessorCount => _successors.Count;

        public void AddSuccessor(string word)
        {
            var successor = new Word(word);

            if (_successors.ContainsKey(successor))
                _successors[successor]++;
            else
                _successors[successor] = 1;
        }

        public void AddSuccessor(Word word)
        {
            AddSuccessor(word.Content);
        }

        public Word GetNext()
        {
            var sum = _successors.Sum(s => s.Value);

            var target = Rng.Random.Next(0, sum);

            foreach (var successor in _successors)
            {
                if (target < successor.Value)
                    return successor.Key;

                target -= successor.Value;
            }

            return _successors.Keys.First();
        }
    }
}
