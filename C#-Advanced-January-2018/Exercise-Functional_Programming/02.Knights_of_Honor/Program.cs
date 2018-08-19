using System;
using System.Linq;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printResult = a => Console.WriteLine("Sir " + a);
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(e => printResult(e));
        }
    }
}
