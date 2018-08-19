using System;
using System.Linq;

namespace _04.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            int[,] matrix = new int[rows, cows];
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                var letters = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    matrix[rowsCount, cowsCount] = letters[cowsCount];
                }
            }
            var maxSum = int.MinValue;
            var startMaxRow = 0;
            var startMaxCow = 0;
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0) - 2; rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1) - 2; cowsCount++)
                {
                    var currentSum = 0;
                    for (int innerRow = rowsCount; innerRow < rowsCount + 3; innerRow++)
                    {
                        for (int innerCow = cowsCount; innerCow < cowsCount + 3; innerCow++)
                        {
                            currentSum += matrix[innerRow, innerCow];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startMaxRow = rowsCount;
                        startMaxCow = cowsCount;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int rowsCount = startMaxRow; rowsCount < startMaxRow + 3; rowsCount++)
            {
                for (int cowsCount = startMaxCow; cowsCount < startMaxCow + 3; cowsCount++)
                {
                    Console.Write(matrix[rowsCount, cowsCount] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
