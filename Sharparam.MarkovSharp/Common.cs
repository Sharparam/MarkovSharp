namespace Sharparam.MarkovSharp
{
    using System.Text.RegularExpressions;

    public static class Common
    {
        public static readonly Regex PunctuationRegex = new Regex(@"[\.?!]$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static readonly Regex WordRegex = new Regex(@"([\w'\-]+)([,.!?]*)", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    }
}
