using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReaderWords = new StreamReader("../../../words.txt"))
            {
                using (var streamReaderText = new StreamReader("../../../text.txt"))
                {
                    using (var streamWriter = new StreamWriter("../../../result.txt"))
                    {
                        var book = new Dictionary<string, int>();
                        string word;
                        while ((word = streamReaderWords.ReadLine()) != null)
                        {
                            if (!book.ContainsKey(word))
                            {
                                book[word] = 0;
                            }
                        }
                        var line = streamReaderText.ReadLine().ToLower();
                        while(line != null)
                        {
                            var currentLine = line.ToLower();
                            foreach (var key in book.Keys.ToList())
                            {
                                var match = Regex.Matches(currentLine, $@"\b{key}\b");
                                book[key] += match.Count;
                            }
                            line = streamReaderText.ReadLine();
                        }
                        foreach (var item in book.OrderByDescending(a => a.Value))
                        {
                            streamWriter.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                }
            }
        }
    }
}