using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Srabsko_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^(.*?)\s@(.*?)\s([0-9]+)\s([0-9]+)$";
            var book = new Dictionary<string, Dictionary<string, long>>();
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                Match match = Regex.Match(line, pattern);
                if (!match.Success)
                {
                    continue;
                }
                var singer = match.Groups[1].Value;
                var venue = match.Groups[2].Value;
                var ticketsPrice = long.Parse(match.Groups[3].Value);
                var ticketsCount = long.Parse(match.Groups[4].Value);
          
                AddBookItems(book, singer, venue, ticketsPrice, ticketsCount);
            }
            PrintResult(book);
        }

        private static void AddBookItems(Dictionary<string, Dictionary<string, long>> book, 
            string singer, string venue, long ticketsPrice, long ticketsCount)
        {
            if (!book.ContainsKey(venue))
            {
                book[venue] = new Dictionary<string, long>();
            }
            if (!book[venue].ContainsKey(singer))
            {
                book[venue][singer] = 0;
            }
            book[venue][singer] += (ticketsPrice * ticketsCount);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> book)
        {
            foreach (var pair in book)
            {
                Console.WriteLine(pair.Key);
                foreach (var item in pair.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}