using System;
using System.Linq;

namespace _02.Square_With_Maximum_Sum
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
            var startIndexRow = 0;
            var startIndexCow = 0;
            var currentMaxSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int cow = 0; cow < matrix.GetLength(1); cow++)
                {
                    if (row + 1 < matrix.GetLength(0) && cow + 1 < matrix.GetLength(1))
                    {
                        var momentSum = GetMomentSum(matrix, row, cow);
                        if (momentSum > currentMaxSum)
                        {
                            currentMaxSum = momentSum;
                            startIndexRow = row;
                            startIndexCow = cow;
                        }
                    }
                }
            }
            Console.WriteLine(matrix[startIndexRow, startIndexCow] + " " + matrix[startIndexRow, startIndexCow + 1]);
            Console.WriteLine(matrix[startIndexRow + 1, startIndexCow] + " " + matrix[startIndexRow + 1, startIndexCow + 1]);
            Console.WriteLine(currentMaxSum);
        }

        private static int GetMomentSum(int[,] matrix, int row, int cow)
        {
            var sum = 0;
            for (int rowCount = row; rowCount < row + 2; rowCount++)
            {
                for (int cowCount = cow; cowCount < cow + 2; cowCount++)
                {
                    sum += matrix[rowCount, cowCount];
                }
            }
            return sum;
        }
    }
}