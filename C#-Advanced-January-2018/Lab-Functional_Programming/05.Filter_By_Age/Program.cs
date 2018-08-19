using System;
using System.Collections.Generic;

namespace _05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var book = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                book[tokens[0]] = int.Parse(tokens[1]);
            }
            var format = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var typeOfPrint = Console.ReadLine();
            var filter = Getfilter(format, age);
            var printFunc = GetPrint(typeOfPrint);
            PrintResult(book, filter, printFunc);
        }

        private static void PrintResult(
            Dictionary<string, int> book, 
            Func<int, bool> filter, 
            Action<KeyValuePair<string, int>> printFunc)
        {
            foreach (var item in book)
            {
                if (filter(item.Value))
                {
                    printFunc(item);
                }
            }
        }

        static Action<KeyValuePair<string, int>> GetPrint(string typeOfPrint)
        {
            switch (typeOfPrint)
            {
                case "name":
                    return a => Console.WriteLine(a.Key);
                case "age":
                    return a => Console.WriteLine(a.Value);
                case "name age":
                    return a => Console.WriteLine($"{a.Key} - {a.Value}");
                default:
                    throw new Exception();
            }
        }

        static Func<int, bool> Getfilter(string format, int age)
        {
            if (format == "younger")
            {
                return a => a < age;
            }
            else
            {
                return a => a >= age;
            }
        }
    }
}
