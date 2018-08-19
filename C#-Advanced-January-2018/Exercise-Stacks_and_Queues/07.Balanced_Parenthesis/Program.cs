using System;
using System.Collections.Generic;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            var openedBrackets = "[{(";
            var closedBrackets = "]})";

            for (int i = 0; i < input.Length; i++)
            {
                var currentBracket = input[i];
                if (openedBrackets.IndexOf(currentBracket) > -1)
                {
                    stack.Push(currentBracket);
                }
                else if (closedBrackets.IndexOf(currentBracket) > -1)
                {
                    if (stack.Count == 0 || closedBrackets.IndexOf(currentBracket) != openedBrackets.IndexOf(stack.Pop()))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
			if (stack.Count != 0)
			{
				Console.WriteLine("NO");
			}
			else
			{
				Console.WriteLine("YES");
			}           
        }
    }
}
