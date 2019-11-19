using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Varaibles needed
            string OpenFile = File.ReadAllText("C:\\Work\\Training\\EmailExtraction\\Sample.txt");
            Dictionary<string, int> addresses = new Dictionary<string, int>();

            //Set up Regular Expressions, needed to find what addresses
            Regex softwireRX = new Regex(@"@softwire.com\s",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex corndelRX = new Regex(@"@corndel.com\s",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //Use the expressions to find matches
            MatchCollection matchesSoftwire = softwireRX.Matches(OpenFile);
            MatchCollection matchesCorndel = corndelRX.Matches(OpenFile);

            addresses.Add("Softwire", matchesSoftwire.Count);
            addresses.Add("Corndel", matchesCorndel.Count);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
