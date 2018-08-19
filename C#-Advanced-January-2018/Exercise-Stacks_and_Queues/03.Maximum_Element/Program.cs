using System;
using System.Collections.Generic;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();
            maxStack.Push(0);
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var command = line[0];
                switch(command)
                {
                    case '1':
                        var element = "";
                        for (int j = 2; j < line.Length; j++)
                        {
                            element += line[j];
                        }
                        var num = int.Parse(element);
                        stack.Push(num);
                        if (maxStack.Peek() < num)
                        {
                            maxStack.Push(num);
                        }
                        break;
                    case '2':
                        if (maxStack.Peek() == stack.Pop())
                        {
                            maxStack.Pop();
                        }
                        break;
                    case '3':
                        Console.WriteLine(maxStack.Peek());
                        break;
                }
            }
        }
    }
}
