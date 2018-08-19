using System;
using System.Collections.Generic;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n, new Dictionary<int, long>()));
        }

        private static long GetFibonacci(int n, Dictionary<int, long> book)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            if (book.ContainsKey(n))
            {
                return book[n];
            }
            else
            {
                book.Add(n, GetFibonacci(n - 1, book) + GetFibonacci(n - 2, book));
                return GetFibonacci(n - 1, book) + GetFibonacci(n - 2, book);
            }
        }
    }
}
