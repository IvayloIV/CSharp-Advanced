using System;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = word => char.IsUpper(word[0]);
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
