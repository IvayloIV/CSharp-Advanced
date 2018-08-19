using System;
using System.IO;
using System.Text;

namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var imageFile = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (var resultFile = new FileStream("../../../result.jpg", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    while(true)
                    {
                        var readBytes = imageFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        resultFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
