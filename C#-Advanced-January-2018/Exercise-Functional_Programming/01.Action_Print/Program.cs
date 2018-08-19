using System;
using System.Linq;

namespace _01.Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printResult = a => Console.WriteLine(a);
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(e => printResult(e));
        }
    }
}