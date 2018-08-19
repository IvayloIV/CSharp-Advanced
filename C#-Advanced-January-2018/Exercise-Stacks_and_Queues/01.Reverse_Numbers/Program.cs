using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a));
            var stack = new Stack<int>(nums);
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
