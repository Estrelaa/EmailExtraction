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
            Regex softwireRX = new Regex(@"@\s",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //Use the expressions to find matches then update our dictionary
            foreach(Match matchesSoftwire in softwireRX.Matches(OpenFile))
            {
                string temp = matchesSoftwire.Value;
                if (addresses.ContainsKey(temp) == false)
                {
                    addresses.Add(temp, 1);
                }
                else
                {
                    addresses[temp] = addresses[temp] + 1;
                }
            }

            foreach (KeyValuePair<string, int> key in addresses)
            {
                Console.WriteLine("{0}", key);
            }
            
            Console.ReadLine();
        }
    }
}
