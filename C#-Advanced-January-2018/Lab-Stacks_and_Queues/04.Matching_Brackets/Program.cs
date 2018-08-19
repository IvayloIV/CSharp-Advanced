using System;
using System.Collections.Generic;

namespace _04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    var positionOpenBracket = stack.Pop(); 
                    var subString = input.Substring(positionOpenBracket, i - positionOpenBracket + 1);
                    Console.WriteLine(subString);
                }
            }
        }
    }
}
