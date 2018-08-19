using System;
using System.Collections.Generic;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 1; i < n; i++)
            {
                var lastNum = stack.Pop();
                var sumiLastNum = stack.Peek();
                stack.Push(lastNum);
                stack.Push(lastNum + sumiLastNum);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
