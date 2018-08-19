using System;
using System.IO;
using System.Text;

namespace File_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream("../../../result.txt", FileMode.Open))
            {
                using (var fileStream = new FileStream("../../../text.txt", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    while(true)
                    {
                        var readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        fileStream.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
