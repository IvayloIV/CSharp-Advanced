using System;
using System.Linq;

namespace _05.Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            int[,] matrix = new int[rows, cows];
            var count = 1;
            for (int rowsCount = 0; rowsCount < rows; rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < cows; cowsCount++)
                {
                    matrix[rowsCount, cowsCount] = count++;
                }
            }
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var direction = tokens[1];
                if (direction == "up" || direction == "down")
                {
                    var currentCow = int.Parse(tokens[0]);
                    var totalMove = int.Parse(tokens[2]);

                    for (int move = 0; move < totalMove % matrix.GetLength(0); move++)
                    {
                        if (direction == "up")
                        {
                            var firstNum = matrix[0, currentCow];
                            for (int currentRow = 0; currentRow < matrix.GetLength(0) - 1; currentRow++)
                            {
                                matrix[currentRow, currentCow] = matrix[currentRow + 1, currentCow];
                            }
                            matrix[matrix.GetLength(0) - 1, currentCow] = firstNum;
                        }
                        else if (direction == "down")
                        {
                            var lastNum = matrix[matrix.GetLength(0) - 1, currentCow];
                            for (int currentRow = matrix.GetLength(0) - 1; currentRow >= 1; currentRow--)
                            {
                                matrix[currentRow, currentCow] = matrix[currentRow - 1, currentCow];
                            }
                            matrix[0, currentCow] = lastNum;
                        }
                    }
                }
                else if (direction == "left" || direction == "right")
                {
                    var currentRow = int.Parse(tokens[0]);
                    var totalMove = int.Parse(tokens[2]);
                    for (int move = 0; move < totalMove % matrix.GetLength(1); move++)
                    {
                        if (direction == "left")
                        {
                            var firstNum = matrix[currentRow, 0];
                            for (int currentCow = 0; currentCow < matrix.GetLength(1) - 1; currentCow++)
                            {
                                matrix[currentRow, currentCow] = matrix[currentRow, currentCow + 1];
                            }
                            matrix[currentRow, matrix.GetLength(1) - 1] = firstNum;
                        }
                        else if (direction == "right")
                        {
                            var lastNum = matrix[currentRow, matrix.GetLength(1) - 1];
                            for (int currentCow = matrix.GetLength(1) - 1; currentCow >= 1; currentCow--)
                            {
                                matrix[currentRow, currentCow] = matrix[currentRow, currentCow - 1];
                            }
                            matrix[currentRow, 0] = lastNum;
                        }
                    }
                }
            }

            count = 1;
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    var originNum = count++;
                    if (originNum == matrix[rowsCount, cowsCount])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int innerRow = 0; innerRow < matrix.GetLength(0); innerRow++)
                        {
                            var isFind = false;
                            for (int innerCow = 0; innerCow < matrix.GetLength(1); innerCow++)
                            {
                                if (originNum == matrix[innerRow, innerCow])
                                {
                                    var helper = matrix[rowsCount, cowsCount];
                                    matrix[rowsCount, cowsCount] = originNum;
                                    matrix[innerRow, innerCow] = helper;
                                    Console.WriteLine($"Swap ({rowsCount}, {cowsCount}) with ({innerRow}, {innerCow})");
                                    isFind = true;
                                    break;
                                }
                            }
                            if (isFind)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}