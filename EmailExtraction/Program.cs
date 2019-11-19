using System;
using System.IO;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int Counter = 0;
            string OpenFile = File.ReadAllText("C:\\Work\\Training\\EmailExtraction\\Sample.txt");
            string[] TextFromFile = OpenFile.Split();


            for (int i = 0; i < TextFromFile.Length; i++ )
            {
                string temp = TextFromFile.GetValue(i).ToString();
                if (temp.Length > 13)
                {
                    temp.Substring(temp.Length - 13);

                    if (temp.Contains("@softwire.com"))
                    {
                        Counter++;
                        Console.WriteLine(Counter);
                    }
                }
                
            }

            Console.ReadLine();
        }
    }
}
