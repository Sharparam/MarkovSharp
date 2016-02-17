namespace Sharparam.MarkovSharp.Console
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using static System.Console;

    public static class Program
    {
        private static Generator Generator;

        public static void Main()
        {
            Generator = new Generator();

            ParseFile("data.txt");

            WriteLine("Parsing additional files from data.d...");

            if (Directory.Exists("data.d"))
            {
                foreach (var file in Directory.EnumerateFiles("data.d"))
                {
                    ParseFile(file);
                }
            }

            WriteLine("Press N (or any key other than Q) to generate a new sentence (25 words), press Q to exit.");

            while (ReadKey(true).Key != ConsoleKey.Q)
                WriteLine(Generator.Generate(25));
        }

        private static void ParseFile(string file)
        {
            Write("Parsing {0}... ", file);

            var watch = new Stopwatch();
            watch.Start();

            using (var reader = File.OpenText(file))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                    Generator.Parse(line);
            }

            watch.Stop();

            WriteLine("{0:#.000} secs.", watch.Elapsed.TotalSeconds);
        }
    }
}
