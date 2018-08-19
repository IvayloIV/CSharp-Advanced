using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, @"\[[^[\s]+<([0-9]+)REGEH([0-9]+)>[^]\s]+]");
            var indexes = new List<int>();
            foreach (Match match in matches)
            {
                indexes.Add(int.Parse(match.Groups[1].Value));
                indexes.Add(int.Parse(match.Groups[2].Value));
            }
            var sum = 0;
            foreach (var index in indexes)
            {
                sum += index;
                var currentIndex = sum % input.Length;
                Console.Write(input[currentIndex]);
            }
            Console.WriteLine();
        }
    }
}