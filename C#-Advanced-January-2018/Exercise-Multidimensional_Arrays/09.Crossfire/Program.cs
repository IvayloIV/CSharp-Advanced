using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            var matrix = new List<List<long>>();
            var counter = 1;
            for (int rowsCount = 0; rowsCount < rows; rowsCount++)
            {
                matrix.Add(new List<long>());
                for (int cowsCount = 0; cowsCount < cows; cowsCount++)
                {
                    matrix[rowsCount].Add(counter++);
                }
            }
            while (true)
            {
                var token = Console.ReadLine();
                if (token == "Nuke it from orbit")
                {
                    break;
                }
                var tokens = token.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var pointRow = tokens[0];
                var pointCow = tokens[1];
                var radius = tokens[2];
                var minRow = Math.Max(0, pointRow - radius);
                var maxRow = Math.Min(matrix.Count - 1, pointRow + radius);

                var helper = 0;
                if (pointCow >= 0)
                {
                    for (int rowsCount = minRow; rowsCount <= maxRow; rowsCount++)
                    {
                        if (pointCow < matrix[rowsCount].Count)
                        {
                            helper = 1;
                            matrix[rowsCount].RemoveAt(pointCow);
                        }
                    }
                }

                if (pointRow >= 0 && pointRow < matrix.Count)
                {
                    var minCow = Math.Max(0, pointCow - radius);
                    var maxCow = Math.Min(matrix[pointRow].Count - 1, pointCow + radius - helper);
                    for (int cowsCount = maxCow; cowsCount >= minCow; cowsCount--)
                    {
                        matrix[pointRow].RemoveAt(cowsCount);
                    }
                }

                for (int rowsCount = 0; rowsCount < matrix.Count; rowsCount++)
                {
                    if (matrix[rowsCount].Count == 0)
                    {
                        matrix.RemoveAt(rowsCount);
                    }
                }
            }
            for (int rowsCount = 0; rowsCount < matrix.Count; rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix[rowsCount].Count; cowsCount++)
                {
                    Console.Write(matrix[rowsCount][cowsCount] + " ");
                }
                if (matrix[rowsCount].Count != 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}