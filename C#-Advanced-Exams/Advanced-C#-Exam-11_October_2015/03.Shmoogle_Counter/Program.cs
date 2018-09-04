using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Shmoogle_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(int|double)\s+([a-z][A-Za-z]*)";
            var intList = new List<string>();
            var doubleList = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != "//END_OF_CODE")
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    var variable = match.Groups[1].Value;
                    var name = match.Groups[2].Value;
                    if (variable == "int")
                    {
                        intList.Add(name);
                    }
                    else if (variable == "double")
                    {
                        doubleList.Add(name);
                    }
                }
            }
            Console.WriteLine($"Doubles: " + (doubleList.Count == 0 ? "None" : string.Join(", ", doubleList.OrderBy(a => a))));
            Console.WriteLine($"Ints: " + (intList.Count == 0 ? "None" : string.Join(", ", intList.OrderBy(a => a))));
        }
    }
}