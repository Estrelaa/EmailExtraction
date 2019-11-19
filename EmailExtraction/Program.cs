using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Varaibles needed
            string OpenFile = File.ReadAllText("C:\\Work\\Training\\EmailExtraction\\Sample.txt");
            Dictionary<string, int> addresses = new Dictionary<string, int>();
            int counter = 1;
            int userFrequencyInput = 0;

            //Set up Regular Expressions, needed to find what addresses
            Regex softwireRX = new Regex(@"@[a-zA-Z0-9-_.]+",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            /*Use the expressions to find matches then update our dictionary 
             * depending on if they are already in it or not
             */
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

            // print the addresses and how many times they appeared
            foreach (KeyValuePair<string, int> key in addresses)
            {
                Console.WriteLine("Key: {0}", key);
            }

            // Make two blank lines then print the addresses in value order
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("In order: ");
            Console.WriteLine("");

            foreach (KeyValuePair<string, int> key in addresses.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("Key {0}: {1}", counter++, key);
            }


            // Reset the counter, then ask the user for the frequency, then if the frequency value is above the dict value, print it and the key.
            counter = 1;
            Console.WriteLine("Enter Frequency: ");
            userFrequencyInput = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Filtered with Frequency and ordered: ");
            Console.WriteLine("");

            foreach (KeyValuePair<string, int> key in addresses.OrderByDescending(key => key.Value))
            {
                if(key.Value > userFrequencyInput)
                {
                    Console.WriteLine("Key {0}: {1}", counter++, key);
                }
              
            }

            // Stops the console window from closing
            Console.ReadLine();
        }
    }
}
