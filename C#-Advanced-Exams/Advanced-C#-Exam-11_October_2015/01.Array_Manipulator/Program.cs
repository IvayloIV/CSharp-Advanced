using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            ReadCommands(ref numbers);
            PrintDefaultFormat(numbers);
        }

        private static void ReadCommands(ref List<int> numbers)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokens[0];
                numbers = Processor(numbers, tokens, command);
            }
        }

        private static List<int> Processor(List<int> numbers, List<string> tokens, string command)
        {
            switch (command)
            {
                case "exchange":
                    numbers = ExchangeNums(tokens, numbers);
                    break;
                case "max":
                case "min":
                    FindMinMaxNum(tokens, numbers);
                    break;
                case "first":
                case "last":
                    FindFirstLastCount(tokens, numbers);
                    break;
            }

            return numbers;
        }

        private static void FindFirstLastCount(List<string> tokens, List<int> numbers)
        {
            var command = tokens[0];
            var count = int.Parse(tokens[1]);
            var type = tokens[2];
            if (count > numbers.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            var filterNums = FilterNumsByOddEven(numbers, type);
            if (command == "first")
            {
                PrintDefaultFormat(filterNums.Take(count).ToList());
                
            }
            else if (command == "last")
            {
                PrintDefaultFormat(filterNums.Skip(filterNums.Count - count).ToList());
            }
        }

        private static void PrintDefaultFormat(List<int> numbers)
        {
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }

        private static void FindMinMaxNum(List<string> tokens, List<int> numbers)
        {
            var type = tokens[1];
            var command = tokens[0];
            List<int> filterNums = FilterNumsByOddEven(numbers, type);
            if (filterNums.Count == 0)
            {
                Console.WriteLine("No matches");
            }
            else if (command == "max") 
            {
                var maxNum = filterNums.Max();
                Console.WriteLine(numbers.LastIndexOf(maxNum));
            }
            else if (command == "min")
            {
                var minNum = filterNums.Min();
                Console.WriteLine(numbers.LastIndexOf(minNum));
            }
        }

        private static List<int> FilterNumsByOddEven(List<int> numbers, string type)
        {
            if (type == "even")
            {
                return numbers.Where(a => a % 2 == 0).ToList();
            }
            else
            {
                return numbers.Where(a => a % 2 == 1).ToList();
            }
        }

        private static List<int> ExchangeNums(List<string> tokens, List<int> numbers)
        {
            var index = int.Parse(tokens[1]);
            if (index < 0 || index > numbers.Count - 1)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }
            var leftPart = numbers.Take(index + 1).ToList();
            var rightPart = numbers.Skip(index + 1).ToList();
            return rightPart.Concat(leftPart).ToList();
        }
    }
}