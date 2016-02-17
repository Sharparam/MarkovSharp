namespace Sharparam.MarkovSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Generator
    {
        private static readonly List<WordData> Data = new List<WordData>();

        public void Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            foreach (var sentence in new Sentences(input))
            {
                WordData previous = null;

                foreach (var word in sentence)
                {
                    var data = Data.FirstOrDefault(d => d.Word == word);

                    if (data == null)
                    {
                        data = new WordData(word);
                        Data.Add(data);
                    }

                    previous?.AddSuccessor(data.Word);

                    previous = data;
                }
            }
        }

        public string Generate(int wordLimit, string seed = null)
        {
            var data = Data.FirstOrDefault(d => d.Word == seed) ?? Data[Rng.Random.Next(0, Data.Count)];

            var result = new List<Word>(wordLimit);
            
            for (var c = 0; c < wordLimit; c++)
            {
                result.Add(data.Word);

                if (data.SuccessorCount == 0)
                    break;

                var next = data.GetNext();
                
                data = Data.First(d => d.Word == next);
            }

            return string.Join(" ", result);
        }

        public string Generate(int wordLimit, Word seed)
        {
            return Generate(wordLimit, seed.Content);
        }
    }
}
