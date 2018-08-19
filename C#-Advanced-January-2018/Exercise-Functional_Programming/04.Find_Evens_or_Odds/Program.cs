using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var filter = GetFilter(Console.ReadLine());
            var allNums = new List<int>();
            for (int i = tokens[0]; i <= tokens[1]; i++)
            {
                if (filter(i))
                {
                    allNums.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", allNums));
        }

        static Func<int, bool> GetFilter(string command)
        {
            if (command == "odd")
            {
                return a => Math.Abs(a) % 2 == 1;
            }
            else
            {
                return a => Math.Abs(a) % 2 == 0;
            }
        }
    }
}
