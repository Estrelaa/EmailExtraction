using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int Counter = 0;
            Regex rx = new Regex(@"@softwire.com\s",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string OpenFile = File.ReadAllText("C:\\Work\\Training\\EmailExtraction\\Sample.txt");
            MatchCollection matches = rx.Matches(OpenFile);
            string[] TextFromFile = OpenFile.Split();

            Console.WriteLine(matches.Count);
            Console.ReadLine();
        }
    }
}
