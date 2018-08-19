using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var totalCommands = new List<string>();
            Func<string, string, bool> filter = (a, b) => a != b;
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "Forge")
                {
                    break;
                }
                var tokens = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                var comamnd = tokens[0];
                var filterType = tokens[1];
                var parameter = tokens[2];
                var summary = $"{filterType} - {parameter}";
                if (comamnd == "Exclude")
                {
                    totalCommands.Add(summary);
                }
                else if (comamnd == "Reverse")
                {
                    totalCommands = totalCommands.Where(a => filter(a, summary)).ToList();
                }
            }
            var helper = new List<int>(numbers);
            foreach (var command in totalCommands)
            {
                var tokens = command.Split(new[] { " - " }, StringSplitOptions.None).ToList();
                var filterType = tokens[0];
                var parameter = int.Parse(tokens[1]);
                var currentFilter = GetFuncSum(filterType);
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (currentFilter(numbers, i) == parameter)
                    {
                        helper[i] = -123;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", helper.Where(a => a != -123).ToList()));
        }

        static Func<List<int>, int, int> GetFuncSum(string command)
        {
            switch (command)
            {
                case "Sum Left":
                    return (nums, index) => {
                        var sum = 0;
                        if (index - 1 >= 0)
                        {
                            sum += nums[index - 1];
                        }
                        sum += nums[index];
                        return sum;
                    };
                case "Sum Right":
                    return (nums, index) => {
                        var sum = 0;
                        if (index + 1 < nums.Count)
                        {
                            sum += nums[index + 1];
                        }
                        sum += nums[index];
                        return sum;
                    };
                case "Sum Left Right":
                    return (nums, index) => {
                        var sum = 0;
                        sum += GetFuncSum("Sum Left")(nums, index);
                        sum += GetFuncSum("Sum Right")(nums, index);
                        sum -= nums[index];
                        return sum;
                    };
                default:
                    throw new Exception();
            }
        }
    }
}
