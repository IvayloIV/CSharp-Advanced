using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            StringBuilder row = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                row.Append(Console.ReadLine());
            }
            var patternName = Console.ReadLine();
            var patternMessage = Console.ReadLine();
            var totalNames = new List<string>();
            var totalMessages = new List<string>();

            var matchetNames = Regex.Matches(row.ToString(), patternName + @"([A-Z-a-z]{" + patternName.Length + "})(?![a-zA-Z])");
            foreach (Match name in matchetNames)
            {
                totalNames.Add(name.Groups[1].Value);
            }
            var matchetMessage = Regex.Matches(row.ToString(), patternMessage + @"([A-Z-a-z0-9]{" + patternMessage.Length + "})(?![a-zA-Z0-9])");
            foreach (Match message in matchetMessage)
            {
                totalMessages.Add(message.Groups[1].Value);
            }

            var indexes = new Queue<int>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            for (int i = 0; i < totalNames.Count; i++)
            {
                while (indexes.Count > 0)
                {
                    var index = indexes.Dequeue() - 1;
                    if (index >= 0 && index < totalMessages.Count)
                    {
                        Console.WriteLine($"{totalNames[i]} - {totalMessages[index]}");
                        break;
                    }
                }
                if (indexes.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
