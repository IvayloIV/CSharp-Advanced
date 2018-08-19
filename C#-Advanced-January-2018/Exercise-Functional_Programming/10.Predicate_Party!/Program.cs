using System;
using System.Collections.Generic;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Party!")
                {
                    break;
                }
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var typeOfCommand = tokens[1];
                var helper = tokens[2];
                var filter = GetFilter(typeOfCommand, helper);
                var commandService = GetCommand(command);
                var helperNames = new List<string>();
                foreach (var name in names)
                {
                    helperNames.Add(name);
                    if (filter(name))
                    {
                        helperNames = commandService(helperNames, name);
                    }
                }
                names = helperNames.ToArray();
            }
            if (names.Length == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", names) + " are going to the party!");
            }
        }

        static Func<List<string>, string, List<string>> GetCommand(string command)
        {
            switch (command)
            {
                case "Double":
                    return (names, currentName) => {
                        names.Add(currentName);
                        return names;
                    };
                case "Remove":
                    return (names, currentName) => {
                        var index = names.IndexOf(currentName);
                        names.RemoveAt(index);
                        return names;
                    };
                default:
                    throw new Exception();
            }
        }

        static Func<string, bool> GetFilter (string typeOfCommand, string helper)
        {
            switch (typeOfCommand)
            {
                case "StartsWith":
                    return a => a.StartsWith(helper);
                case "EndsWith":
                    return a => a.EndsWith(helper);
                case "Length":
                    return a => a.Length == int.Parse(helper);
                default:
                    throw new Exception();
            }
        }
    }
}
