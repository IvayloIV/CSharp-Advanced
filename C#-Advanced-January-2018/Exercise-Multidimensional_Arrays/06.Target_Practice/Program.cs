using System;
using System.Linq;

namespace _06.Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            var word = Console.ReadLine();
            char[,] matrix = new char[rows, cows];
            var count = 0;
            var isReversed = true;
            for (int rowsCount = matrix.GetLength(0) - 1; rowsCount >= 0; rowsCount--)
            {
                for (int cowsCount = matrix.GetLength(1) - 1; cowsCount >= 0; cowsCount--)
                {
                    if (isReversed)
                    {
                        matrix[rowsCount, cowsCount] = word[count % word.Length];
                    }
                    else
                    {
                        matrix[rowsCount, matrix.GetLength(1) - 1 - cowsCount] = word[count % word.Length];
                    }
                    count++;
                }
                isReversed = !isReversed;
            }
            var points = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var startRow = points[0];
            var startCow = points[1];
            var radius = points[2];
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    if (radius >= Math.Sqrt(Math.Pow(rowsCount - startRow, 2) + Math.Pow(cowsCount - startCow, 2)))
                    {
                        matrix[rowsCount, cowsCount] = ' ';
                    }
                }
            }
            for (int rowCount = 0; rowCount < matrix.GetLength(0) - 1; rowCount++)
            {
                for (int cowCount = 0; cowCount < matrix.GetLength(1); cowCount++)
                {
                    if (matrix[rowCount + 1, cowCount] == ' ')
                    {
                        for (int innerRow = rowCount + 1; innerRow >= 1; innerRow--)
                        {
                            matrix[innerRow, cowCount] = matrix[innerRow - 1, cowCount];
                            matrix[innerRow - 1, cowCount] = ' ';
                        }
                    }
                }
            }
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowCount = 0; cowCount < matrix.GetLength(1); cowCount++)
                {
                    Console.Write(matrix[rowsCount, cowCount]);
                }
                Console.WriteLine();
            }
        }
    }
}
