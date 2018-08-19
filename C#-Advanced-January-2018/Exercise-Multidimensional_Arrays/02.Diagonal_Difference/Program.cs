using System;
using System.Linq;

namespace _02.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var nums = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cow = 0; cow < n; cow++)
                {
                    matrix[i, cow] = nums[cow];
                }
            }
            var leftDiagonal = 0;
            var rigthDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                leftDiagonal += matrix[row, row];
                rigthDiagonal += matrix[row, matrix.GetLength(0) - 1 - row];
            }
            Console.WriteLine(Math.Abs(leftDiagonal - rigthDiagonal));
        }
    }
}
