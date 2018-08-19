using System;
using System.Collections.Generic;
using System.Numerics;

namespace _03.Softuni_Numerals
{
    class Program
    {
        static int index = 0;
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            while (index < input.Length)
            {
                stack.Push(GetCode(input));
            }
            BigInteger sum = 0;
            var count = 0;
            while (stack.Count > 0)
            {
                BigInteger pow = 1;
                for (int i = 1; i <= count; i++)
                {
                    pow *= 5;
                }
                sum += stack.Pop() * pow;
                count++;
            }
            Console.WriteLine(sum);
        }

        private static int GetCode(string input)
        {
            if (input.Substring(index, 2) == "aa")
            {
                index += 2;
                return 0;
            }
            else if (input.Substring(index, 2) == "cc")
            {
                index += 2;
                return 3;
            }
            else if (input.Substring(index, 3) == "aba")
            {
                index += 3;
                return 1;
            }
            else if (input.Substring(index, 3) == "bcc")
            {
                index += 3;
                return 2;
            }
            else if (input.Substring(index, 3) == "cdc")
            {
                index += 3;
                return 4;
            }
            throw new Exception();
        }
    }
}
