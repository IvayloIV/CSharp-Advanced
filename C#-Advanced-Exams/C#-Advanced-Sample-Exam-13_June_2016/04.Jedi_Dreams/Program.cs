using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Jedi_Dreams
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var book = new Dictionary<string, List<string>>();
            var currentMethod = "";
            var pattern = @"([A-Z][a-zA-Z]*)\s*\(";
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if (input.Trim().StartsWith("static"))
                {
                    var tokens = input.Trim().Split(new[] { " ", "(" }, StringSplitOptions.RemoveEmptyEntries);
                    var methodName = tokens[2];
                    currentMethod = methodName;
                    if (!book.ContainsKey(methodName))
                    {
                        book[methodName] = new List<string>();
                    }
                }
                else if (input.Trim() == "{" && currentMethod != "")
                {
                    var openIndex = input.IndexOf("{");
                    var closeIndex = -1;
                    var text = "";
                    while (true)
                    {
                        if (i + 1 >= n || openIndex == closeIndex)
                        {
                            break;
                        }
                        var newLine = Console.ReadLine();
                        i++;
                        if (newLine.Trim() == "}")
                        {
                            closeIndex = newLine.IndexOf("}");
                        }
                        else
                        {
                            text += newLine;
                        }
                    }
                    AddMethods(book, currentMethod, text, pattern);
                    currentMethod = "";
                }
            }
            PrintResult(book);
        }

        private static void PrintResult(Dictionary<string, List<string>> book)
        {
            foreach (var pair in book.OrderByDescending(a => a.Value.Count).ThenBy(a => a.Key))
            {
                if (pair.Value.Count != 0)
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value.Count} -> {String.Join(", ", pair.Value.OrderBy(a => a))}");
                }
                else
                {
                    Console.WriteLine($"{pair.Key} -> None");
                }
            }
        }

        static void AddMethods(Dictionary<string, List<string>> book, string currentMethod, string text, string pattern)
        {
            var matchElement = Regex.Matches(text, pattern);
            foreach (Match item in matchElement)
            {
                var methodName = item.Groups[1].Value;
                book[currentMethod].Add(methodName);
            }
        }
    }
}