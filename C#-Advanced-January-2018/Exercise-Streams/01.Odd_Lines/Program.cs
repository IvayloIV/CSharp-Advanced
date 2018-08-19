using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("../../../text.txt"))
            {
                string line = streamReader.ReadLine();
                var counter = 0;
                while (line != null)
                {
                    if (counter++ % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    line = streamReader.ReadLine();
                }
            }
        }
    }
}
