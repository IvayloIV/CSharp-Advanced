using System;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("../../../text.txt"))
            {
                using (var streamWriter = new StreamWriter("../../../output.txt"))
                {
                    string line = streamReader.ReadLine();
                    var counter = 1;
                    while (line != null)
                    {
                        streamWriter.WriteLine("Line " + counter++ + ": " + line);
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
