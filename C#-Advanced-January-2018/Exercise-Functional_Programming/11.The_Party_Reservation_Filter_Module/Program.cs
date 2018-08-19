using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var totalCommands = new List<string>();
            Func<string, string, bool> findCopies = (a, name) => a != name; 
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "Print")
                {
                    break;
                }
                var tokens = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var typeOfCommand = tokens[1];
                var helper = tokens[2];
                var summary = $"{typeOfCommand} - {helper}";
                if (command == "Add filter")
                {
                    totalCommands.Add(summary);
                }
                else
                {
                    totalCommands = totalCommands.Where(a => findCopies(a, summary)).ToList();
                }
            }
            foreach (var curentComamnd in totalCommands)
            {
                var tokens = curentComamnd.Split(new[] { " - " }, StringSplitOptions.None);
                var filter = GetFilter(tokens[0], tokens[1]);
                names = names.Where(filter).ToArray();
            }
            Console.WriteLine(String.Join(" ", names));
        }

        static Func<string, bool> GetFilter(string typeOfCommand, string helper)
        {
            switch (typeOfCommand)
            {
                case "Starts with":
                    return a => !a.StartsWith(helper);
                case "Ends with":
                    return a => !a.EndsWith(helper);
                case "Length":
                    return a => a.Length != int.Parse(helper);
                case "Contains":
                    return a => a.IndexOf(helper) == -1;
                default:
                    throw new Exception();
            }
        }
    }
}
