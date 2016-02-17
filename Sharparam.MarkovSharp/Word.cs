namespace Sharparam.MarkovSharp
{
    using System;
    public struct Word : IEquatable<Word>, IEquatable<string>
    {
        public Word(string content)
        {
            Content = content.ToLower();
        }

        public string Content { get; }

        public static bool operator ==(Word left, Word right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Word left, Word right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Word left, string right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Word left, string right)
        {
            return !left.Equals(right);
        }

        public bool Equals(Word other)
        {
            return Content == other.Content;
        }

        public bool Equals(string other)
        {
            if (string.IsNullOrWhiteSpace(other))
                return false;

            return Content == other.ToLower();
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
