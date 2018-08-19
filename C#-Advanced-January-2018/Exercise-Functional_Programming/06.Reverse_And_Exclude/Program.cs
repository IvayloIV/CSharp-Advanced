using System;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            var n = int.Parse(Console.ReadLine());
            Func<int, bool> isDivided = a => a % n != 0;
            number = number.Where(isDivided).ToList();
            Console.WriteLine(String.Join(" ", number));
        }
    }
}
