using System;

namespace CrawlData
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"https://www.yelp.com/search?find_desc=Wheel+Repair&find_loc=Austin%2C+TX&ns=";
            var data = CrawlExtension.getContent(html);
            foreach (var VARIABLE in data)
            {
                Console.WriteLine(VARIABLE.Name);
                Console.WriteLine(VARIABLE.Address);
                Console.WriteLine(VARIABLE.Phone);
                Console.WriteLine(VARIABLE.Rating);
                Console.WriteLine("--------------------");
            }
           
        }
    }
}
