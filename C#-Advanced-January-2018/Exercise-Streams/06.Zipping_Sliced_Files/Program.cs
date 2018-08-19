using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06.Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new List<string>() {
                "../../../result/Part-0.gz",
                "../../../result/Part-1.gz",
                "../../../result/Part-2.gz",
                "../../../result/Part-3.gz",
                "../../../result/Part-4.gz",
            };
            var destinationDirectory = "../../../assembled";
            Assemble(files, destinationDirectory);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                long bytesPatrs = (long)Math.Ceiling((double)reader.Length / parts);
                if (destinationDirectory == String.Empty)
                {
                    destinationDirectory = "./";
                }
                for (int i = 0; i < parts; i++)
                {
                    var partName = destinationDirectory + $"/Part-{i}.gz";
                    using (var writer = new FileStream(partName, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(writer, CompressionMode.Compress))
                        {
                            var buffer = new byte[4096];
                            var totalBytes = 0;
                            while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                            {
                                compressionStream.Write(buffer, 0, buffer.Length);
                                totalBytes += buffer.Length;
                                if (totalBytes >= bytesPatrs)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            destinationDirectory += $"/assembled.mp4";
            using (var writer = new FileStream(destinationDirectory, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var reader = new FileStream(files[i], FileMode.Open))
                    {
                        var buffer = new byte[4096];
                        using (var decompress = new GZipStream(reader, CompressionMode.Decompress))
                        {
                            var currentRead = decompress.Read(buffer, 0, buffer.Length);
                            while (currentRead > 0)
                            {
                                writer.Write(buffer, 0, currentRead);
                                currentRead = decompress.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }
    }
}