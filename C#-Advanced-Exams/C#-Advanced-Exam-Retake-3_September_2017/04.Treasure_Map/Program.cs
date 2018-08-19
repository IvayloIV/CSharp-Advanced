using System;
using System.Text.RegularExpressions;

namespace TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(!|#)[^!#]*?\b(?<name>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<street>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^!#]*?(?!\1)(!|#)";
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var matches = Regex.Matches(input, pattern);
                var match = matches[matches.Count / 2];
                Console.WriteLine($"Go to str. " +
                    $"{match.Groups["name"].Value} {match.Groups["street"].Value}. " +
                    $"Secret pass: {match.Groups["password"].Value}.");
            }
        }
    }
}