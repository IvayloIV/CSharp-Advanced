using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> findSmaller = (a, b) => a > b;
            var minNum = int.MaxValue;
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .ForEach(n => {
                    if (findSmaller(minNum, n))
                    {
                        minNum = n;
                    }
                });
            Console.WriteLine(minNum);
        }
    }
}
