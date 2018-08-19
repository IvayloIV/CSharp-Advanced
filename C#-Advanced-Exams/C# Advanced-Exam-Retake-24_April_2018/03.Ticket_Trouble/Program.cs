using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = Console.ReadLine();
            var input = Console.ReadLine();
            var matches = Regex.Matches(input, @"((?<opener>\[)|{)(?(opener)[^\[\]]*?|[^\{\}]*?)(?(opener){|\[)" + location +
                @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^\{\}]*?)(?(opener){|\[)(?<letter>[A-Z])(?<number>\d{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^\{\}]*?)(?(opener)\]|})");
            var result = new List<string>();
            foreach (Match match in matches)
            {
                result.Add(match.Groups["letter"].Value + match.Groups["number"].Value);
            }
            if (result.Count > 2)
            {
                result = result.GroupBy(s => s.Substring(1))
                    .Where(g => g.Count() > 1)
                    .Select(g => g.ToList())
                    .First();
            }
            Console.WriteLine($"You are traveling to {location} on seats {result[0]} and {result[1]}.");
        }
    }
}
