using System;
using System.Collections.Generic;
using System.IO;

namespace _05.Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new List<string>() {
                "../../../result/Part-0.mp4",
                "../../../result/Part-1.mp4",
                "../../../result/Part-2.mp4",
                "../../../result/Part-3.mp4",
                "../../../result/Part-4.mp4",
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
                var extenshion = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                for (int i = 0; i < parts; i++)
                {
                    var partName = destinationDirectory + $"/Part-{i}.{extenshion}";
                    using (var writer = new FileStream(partName, FileMode.Create))
                    {
                        var buffer = new byte[4096];
                        var totalBytes = 0;
                        while(reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            writer.Write(buffer, 0 , buffer.Length);
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

        static void Assemble(List<string> files, string destinationDirectory)
        {
            var extension = files[0].Substring(files[0].LastIndexOf('.') + 1);
            destinationDirectory += $"/assembled.{extension}";
            using (var writer = new FileStream(destinationDirectory, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var reader = new FileStream(files[i], FileMode.Open))
                    {
                        var buffer = new byte[4096];
                        var currentRead = reader.Read(buffer, 0, buffer.Length);
                        while (currentRead > 0)
                        {
                            writer.Write(buffer, 0 ,currentRead);
                            currentRead = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}