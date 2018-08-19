using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> printResult = n => Console.WriteLine(String.Join(" ", n));
            var nums = Console.ReadLine()
                .Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                else if (input == "print")
                {
                    printResult(nums);
                    continue;
                }
                var filter = GetFilter(input);
                nums = nums.Select(filter).ToList();
            }
        }

        static Func<int, int> GetFilter(string command)
        {
            switch (command)
            {
                case "add":
                    return a => a + 1;
                case "multiply":
                    return a => a * 2;
                case "subtract":
                    return a => a - 1;
                default:
                    throw new Exception();
            }
        }
    }
}
