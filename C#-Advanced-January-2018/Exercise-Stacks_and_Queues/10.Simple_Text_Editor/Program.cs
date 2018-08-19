using System;
using System.Collections.Generic;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            stack.Push("");

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                switch (tokens[0])
                {
                    case "1":
                        stack.Push(stack.Peek() + tokens[1]);
                        break;
                    case "2":
                        var item = stack.Peek();
                        stack.Push(item.Substring(0, item.Length - int.Parse(tokens[1])));
                        break;
                    case "3":
                        Console.WriteLine(stack.Peek()[int.Parse(tokens[1]) - 1]);
                        break;
                    case "4":
                        stack.Pop();
                        break;
                }
            }
        }
    }
}
