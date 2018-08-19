using System;
using System.Linq;

namespace _08.Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            char[,] matrix = new char[rows, cows];
            var bunnyRow = 0;
            var bunnyCow = 0;
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                var tokens = Console.ReadLine().ToCharArray();
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    if (tokens[cowsCount] == 'P')
                    {
                        bunnyRow = rowsCount;
                        bunnyCow = cowsCount;
                        matrix[rowsCount, cowsCount] = '.';
                    }
                    else
                    {
                        matrix[rowsCount, cowsCount] = tokens[cowsCount];
                    }
                }
            }
            var commands = Console.ReadLine().ToCharArray();
            var result = "";
            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];
                var isOut = false;
                if (currentCommand == 'L')
                {
                    bunnyCow--;
                } 
                else if (currentCommand == 'R')
                {
                    bunnyCow++;
                }
                else if (currentCommand == 'U')
                {
                    bunnyRow--;
                }
                else if (currentCommand == 'D')
                {
                    bunnyRow++;
                }
                if (bunnyRow < 0 || bunnyRow > matrix.GetLength(0) - 1
                    || bunnyCow < 0 || bunnyCow > matrix.GetLength(1) - 1)
                {
                    isOut = true;
                    bunnyRow = Math.Max(0, bunnyRow);
                    bunnyRow = Math.Min(matrix.GetLength(0) - 1, bunnyRow);
                    bunnyCow = Math.Max(0, bunnyCow);
                    bunnyCow = Math.Min(matrix.GetLength(1) - 1, bunnyCow);
                    result = $"won: {bunnyRow} {bunnyCow}";
                }
                char[,] helper = new char[rows, cows]; 
                for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
                {
                    for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                    {
                        if (matrix[rowsCount, cowsCount] == 'B')
                        {
                            if (rowsCount > 0) helper[rowsCount - 1, cowsCount] = 'B';
                            if (rowsCount < matrix.GetLength(0) - 1) helper[rowsCount + 1, cowsCount] = 'B';
                            if (cowsCount > 0) helper[rowsCount, cowsCount - 1] = 'B';
                            if (cowsCount < matrix.GetLength(1) - 1) helper[rowsCount, cowsCount + 1] = 'B';
                        }
                        if (helper[rowsCount, cowsCount] != 'B')
                        {
                            helper[rowsCount, cowsCount] = matrix[rowsCount, cowsCount];
                        }
                    }
                }
                matrix = helper;
                if (isOut == false && matrix[bunnyRow, bunnyCow] == 'B')
                {
                    result = $"dead: {bunnyRow} {bunnyCow}";
                    isOut = true;
                }
                if(isOut)
                {
                    break;
                }
            }

            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    Console.Write(matrix[rowsCount, cowsCount]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(result);
        }
    }
}