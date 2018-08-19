using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pattern = @"^#(?<person>[A-Za-z]+):\s*@(?<location>[A-Za-z]+)\s*(?<hour>[0-9]+):(?<minutes>[0-9]+)$";
            var book = new Dictionary<string, Dictionary<string, List<int>>>();
            for (int i = 0; i < n; i++)
            {
                var match = Regex.Match(Console.ReadLine().Trim(), pattern);
                if (!match.Success)
                {
                    continue;
                }
                var person = match.Groups["person"].Value;
                var location = match.Groups["location"].Value;
                var hour = int.Parse(match.Groups["hour"].Value);
                var minutes = int.Parse(match.Groups["minutes"].Value);
                if (hour >= 24 || minutes >= 60)
                {
                    continue;
                }
                if (!book.ContainsKey(location))
                {
                    book[location] = new Dictionary<string, List<int>>();
                }
                if (!book[location].ContainsKey(person))
                {
                    book[location][person] = new List<int>();
                }
                book[location][person].Add(hour * 3600 + minutes * 60);
            }
            PrintResult(book);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, List<int>>> book)
        {
            var totalLocation = Console.ReadLine().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in book.Where(a => totalLocation.Contains(a.Key)).OrderBy(a => a.Key))
            {
                Console.WriteLine($"{pair.Key}:");
                var count = 1;
                foreach (var innerPair in pair.Value.OrderBy(a => a.Key))
                {
                    Console.WriteLine($"{count++}. {innerPair.Key} -> " +
                        $"{String.Join(", ", innerPair.Value.OrderBy(a => a).Select(a => ConvertSeconds(a)))}");
                }
            }
        }

        static string ConvertSeconds(int secs)
        {
            int hours = secs / 3600;
            int mins = (secs % 3600) / 60;
            return string.Format("{0:D2}:{1:D2}", hours, mins);
        }
    }
}
