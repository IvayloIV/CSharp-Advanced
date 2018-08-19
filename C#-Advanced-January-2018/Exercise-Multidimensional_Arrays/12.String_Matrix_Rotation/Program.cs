using System;
using System.Linq;

namespace _12.String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            var rotates = int.Parse(input[1]) % 360;
            var text = "";
            var maxLength = -1;
            while(true)
            {
                var token = Console.ReadLine();
                if (token == "END")
                {
                    break;
                }
                if (token.Length > maxLength)
                {
                    maxLength = token.Length;
                }
                text += "|" + token;
            }
            var tokens = text.Split(new[] { "|" }, StringSplitOptions.None);
            tokens = tokens.Skip(1).ToArray();
            char[,] matrix = new char[tokens.Length, maxLength];
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    if (cowsCount > tokens[rowsCount].Length - 1)
                    {
                        matrix[rowsCount, cowsCount] = '{';
                    }
                    else
                    {
                        matrix[rowsCount, cowsCount] = tokens[rowsCount][cowsCount];
                    }
                }
            }
            while(rotates > 0)
            {
                var matrixRow = matrix.GetLength(0);
                var matrixCow = matrix.GetLength(1);
                char[,] helper = new char[matrixCow, matrixRow];
                for (int rowsCount = 0; rowsCount < matrix.GetLength(1); rowsCount++)
                {
                    for (int cowsCount = matrix.GetLength(0) - 1; cowsCount >= 0; cowsCount--)
                    {
                        helper[rowsCount, matrix.GetLength(0) - 1 - cowsCount] = matrix[cowsCount, rowsCount];
                    }
                }
                matrix = helper;
                rotates -= 90;
            }
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    if (matrix[rowsCount, cowsCount] == '{')
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(matrix[rowsCount, cowsCount]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}