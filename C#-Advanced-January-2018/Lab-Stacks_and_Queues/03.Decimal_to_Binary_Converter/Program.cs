using System;
using System.Collections.Generic;

namespace _03.Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var decimalNum = int.Parse(Console.ReadLine());
            if (decimalNum == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var stack = new Stack<int>();
            while (decimalNum > 0)
            {
                stack.Push(decimalNum % 2);
                decimalNum /= 2;
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}