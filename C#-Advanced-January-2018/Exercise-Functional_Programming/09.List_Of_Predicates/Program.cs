using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var divideNums = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<int, int, bool> isDivide = (a, b) => a % b == 0;
            var result = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (IsValidNum(divideNums, isDivide, i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }

        private static bool IsValidNum(List<int> divideNums, Func<int, int, bool> isDivide, int i)
        {
            foreach (var divideNum in divideNums)
            {
                if (!isDivide(i, divideNum))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
