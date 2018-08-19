using System;
using System.Linq;

namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isValid = (text, count) => text.ToCharArray().Sum(e => e) >= count;
            var chars = int.Parse(Console.ReadLine());
            PreintResult(isValid, chars);
        }

        private static void PreintResult(Func<string, int, bool> isValid, int chars)
        {
             Console.WriteLine(Console.ReadLine()
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .FirstOrDefault(e => isValid(e, chars)));
        }
    }
}