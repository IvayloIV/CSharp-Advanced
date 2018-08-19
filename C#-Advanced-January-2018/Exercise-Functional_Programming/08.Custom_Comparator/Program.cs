using System;
using System.Linq;

namespace _08.Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<int, bool> isOdd = a => Math.Abs(a) % 2 == 1;
            Func<int, bool> isEven = a => Math.Abs(a) % 2 == 0;
            var evenNums = nums.Where(isEven).ToList().OrderBy(a => a);
            var oddNums = nums.Where(isOdd).ToList().OrderBy(a => a);
            Console.WriteLine(String.Join(" ", evenNums.Concat(oddNums).ToList()));
        }
    }
}
