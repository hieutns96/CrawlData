using System;
using System.IO;

namespace CrawlData
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("locations.txt"))
            {
                // Read a text file line by line.
                string[] lines = File.ReadAllLines("locations.txt");//Write to a file
                using (StreamWriter writer = new StreamWriter("data.txt"))
                {
                    foreach (string location in lines)
                    {
                        var start = 0;
                        var countResult = 0;
                        do
                        {
                            var html = $"https://www.yelp.com/search?find_desc=Wheel+Repair&find_loc={location}&ns=&start={start}";
                            var data = CrawlExtension.getContent(html);
                            foreach (var VARIABLE in data)
                            {
                                Console.WriteLine(VARIABLE.Name);
                                Console.WriteLine(VARIABLE.Address);
                                Console.WriteLine(VARIABLE.Phone);
                                Console.WriteLine(VARIABLE.Rating);
                                Console.WriteLine("--------------------");
                                writer.WriteLine($"{VARIABLE.Name}/{VARIABLE.Address}/{VARIABLE.Phone}/{VARIABLE.Rating}");
                            }
                            
                            countResult = data.Length;
                            start += 10;
                        }
                        while (countResult != 0);
                    }
                }
            }
        }
    }
}
