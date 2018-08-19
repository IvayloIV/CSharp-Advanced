using System;
using System.IO;
using System.Text;

namespace TutorialMemoryStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Example";
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var memoryStream = new MemoryStream(bytes))
            {
                while(true)
                {
                    var readLine = memoryStream.ReadByte();
                    if (readLine == -1)
                    {
                        break;
                    }
                    Console.Write((char)readLine);
                }
                Console.WriteLine();
            }
        }
    }
}
