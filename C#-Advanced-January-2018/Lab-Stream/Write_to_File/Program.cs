using System;
using System.IO;

namespace Write_to_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Program.cs"))
            {
                using (var wrider = new StreamWriter("../../../result.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            wrider.Write(line[i]);
                        }
                        wrider.WriteLine();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}