using System;
using System.Linq;

namespace _03.Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            char[,] matrix = new char[rows, cows];
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                var letters = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    matrix[rowsCount, cowsCount] = char.Parse(letters[cowsCount]);
                }
            }
            var countRepeatMatrix = 0;
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0) - 1; rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1) - 1; cowsCount++)
                {
                    if (matrix[rowsCount, cowsCount] == matrix[rowsCount, cowsCount + 1]
                            && matrix[rowsCount, cowsCount] == matrix[rowsCount + 1, cowsCount]
                            && matrix[rowsCount, cowsCount] == matrix[rowsCount + 1, cowsCount + 1])
                    {
                        countRepeatMatrix++;
                    }
                }
            }
            Console.WriteLine(countRepeatMatrix);
        }
    }
}
