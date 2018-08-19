using System;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isEven = a => a % 2 == 0;
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(isEven)
                .OrderBy(a => a);
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
