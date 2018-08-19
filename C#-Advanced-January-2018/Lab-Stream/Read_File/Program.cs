using System;
using System.IO;

namespace Read_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Program.cs"))
            {
                var line = reader.ReadLine();
                var count = 1;
                while(line != null)
                {
                    Console.WriteLine($"Line {count++}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}
