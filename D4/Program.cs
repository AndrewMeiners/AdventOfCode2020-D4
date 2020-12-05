using System;
using System.Collections.Generic;
using System.Linq;

namespace D4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D4.txt");

            Dictionary<string, string> passport = new Dictionary<string, string>();

            int validPassports = 0;

            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i] != "")
                {
                    string currentLine = lines[i];

                    Dictionary<string, string> dict = currentLine.Split(' ').Select(x => x.Split(':')).ToDictionary(y => y[0], y => y[1]);

                    foreach(var pair in dict)
                    {
                        passport.Add(pair.Key, pair.Value);
                    }
                }

                if (lines[i] == "")
                {
                    if ((passport.Count == 7 && !passport.ContainsKey("cid")) || passport.Count == 8)
                    {
                        validPassports++;
                        passport.Clear();
                    } else
                    {
                        passport.Clear();
                    }
                }

            }

            if ((passport.Count == 7 && !passport.ContainsKey("cid")) || passport.Count == 8)
            {
                validPassports++;
            }

            Console.WriteLine(validPassports);
        }
    }
}
