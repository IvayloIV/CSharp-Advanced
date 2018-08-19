using System;
using System.Linq;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Func<string, bool> isLong = a => a.Length <= n;
            Action<string> printResult = a => Console.WriteLine(a);
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(isLong)
                .ToList()
                .ForEach(printResult);
        }
    }
}
