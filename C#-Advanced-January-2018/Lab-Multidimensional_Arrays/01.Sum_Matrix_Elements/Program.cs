using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            int[,] matrix = new int[rows, cows];
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                var nums = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    matrix[rowsCount, cowsCount] = nums[cowsCount];
                }
            }
            var sum = 0;
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    sum += matrix[rowsCount, cowsCount];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
