using System;
using System.Linq;

namespace _01.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            string[,] matrix = new string[rows, cows];
            for (int rowCount = 97; rowCount < 97 + rows; rowCount++)
            {
                for (int cowsCount = rowCount; cowsCount < rowCount + cows; cowsCount++)
                {
                    var firstLastChar = (char)rowCount;
                    var middleChar = (char)cowsCount;
                    matrix[rowCount - 97, cowsCount - rowCount] = $"{firstLastChar}{middleChar}{firstLastChar}";
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int cow = 0; cow < matrix.GetLength(1); cow++)
                {
                    Console.Write(matrix[row, cow] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}