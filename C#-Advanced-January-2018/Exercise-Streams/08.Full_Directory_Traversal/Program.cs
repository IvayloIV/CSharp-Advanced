﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.Full_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = "../../../../../../../js_advance";
            var book = new Dictionary<string, Dictionary<string, long>>();
            var files = Directory.GetFiles(directory);
            TraverseDirectory(directory, book);
            PrintResult(book);
        }

        private static void TraverseDirectory(string directory, Dictionary<string, Dictionary<string, long>> book)
        {
            var files = Directory.GetFiles(directory);
            TraverseFiles(files, book);
            var innerDirectories = Directory.GetDirectories(directory);
            foreach (var innerDirectory in innerDirectories)
            {
                TraverseDirectory(innerDirectory, book);
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> book)
        {
            using (var writer = new StreamWriter("../../../report.txt"))
            {
                foreach (var item in book.OrderByDescending(a => a.Value.Sum(b => b.Value)).OrderBy(a => a.Key))
                {
                    writer.WriteLine(item.Key);
                    foreach (var innerItem in item.Value.OrderBy(a => a.Value))
                    {
                        var currentSize = innerItem.Value / 1024d;
                        writer.WriteLine($"--{innerItem.Key} - {currentSize:f3}kb");
                    }
                }
            }
        }

        private static void TraverseFiles(string[] files, Dictionary<string, Dictionary<string, long>> book)
        {
            foreach (var file in files)
            {
                var extension = file.Substring(file.LastIndexOf('.'));
                using (var reader = new FileStream(file, FileMode.Open))
                {
                    var buffer = new byte[4096];
                    var totalSize = 0;
                    var currentRead = reader.Read(buffer, 0, buffer.Length);
                    while (currentRead > 0)
                    {
                        totalSize += currentRead;
                        currentRead = reader.Read(buffer, 0, buffer.Length);
                    }
                    if (!book.ContainsKey(extension))
                    {
                        book[extension] = new Dictionary<string, long>();
                    }
                    if (!book[extension].ContainsKey(file))
                    {
                        book[extension][file] = 0;
                    }
                    book[extension][file] += totalSize;
                }
            }
        }
    }
}
