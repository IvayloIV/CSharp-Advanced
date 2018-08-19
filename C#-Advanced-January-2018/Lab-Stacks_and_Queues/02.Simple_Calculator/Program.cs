using System;
using System.Collections.Generic;

namespace _02.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[input.Length - i - 1]);
            }
            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var oprrand = stack.Pop();
                var rigthOperand = int.Parse(stack.Pop());
                if (oprrand == "+")
                {
                    stack.Push((leftOperand + rigthOperand).ToString());
                }
                else if (oprrand == "-")
                {
                    stack.Push((leftOperand - rigthOperand).ToString());
                }
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
