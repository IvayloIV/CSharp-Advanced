using System;
using System.Linq;

namespace _02.Radioactive_Bunnies
{
    class Program
    {
        private static int playerRow = 0;
        private static int playerCow = 0;
        private static bool playerWin = false;

        static void Main(string[] args)
        {
            var inputTokens = Console.ReadLine().Split().Select(int.Parse).ToList();
            var rows = inputTokens[0];
            var cows = inputTokens[1];
            string[,] matrix = new string[rows, cows];

            FillMatrix(rows, cows, matrix);

            var commands = Console.ReadLine().ToCharArray();
            matrix = ReadAndMakeCommands(commands, matrix);
            
            PrintMatrix(matrix);
            FitPlayerIntoMatrix(matrix);
            PrintWinner(playerWin);
        }

        private static string[,] ReadAndMakeCommands(char[] commands, string[,] matrix)
        {
            foreach (var command in commands)
            {
                MovePlayer(command.ToString());
                matrix = MoveBunnies(matrix);
                if (IsPlayerWin(matrix))
                {
                    playerWin = true;
                    break;
                }
                else if (IsEnemyWin(matrix))
                {
                    break;
                }
            }
            return matrix;
        }

        private static void FitPlayerIntoMatrix(string[,] matrix)
        {
            if (playerRow < 0) 
            {
                playerRow = 0;
            }
            else if (playerCow <0)
            {
                playerCow = 0;
            }
            else if (playerRow >= matrix.GetLength(0))
            {
                playerRow = matrix.GetLength(0) -  1;
            }
            else if (playerCow >= matrix.GetLength(1))
            {
                playerCow = matrix.GetLength(1) - 1;
            }
        }

        private static void PrintWinner(bool playerWin)
        {
            var status = playerWin ? "won" : "dead";
            Console.WriteLine($"{status}: {playerRow} {playerCow}");
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    Console.Write(matrix[rowsCount, cowsCount]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsEnemyWin(string[,] matrix)
        {
            return matrix[playerRow, playerCow] == "B";
        }

        private static bool IsPlayerWin(string[,] matrix)
        {
            return playerRow < 0 || playerCow < 0 || playerRow >= matrix.GetLength(0) || playerCow >= matrix.GetLength(1);
        }

        private static string[,] MoveBunnies(string[,] matrix)
        {
            var helper = (string[,])matrix.Clone();
            for (int rowCount = 0; rowCount < matrix.GetLength(0); rowCount++)
            {
                for (int cowCount = 0; cowCount < matrix.GetLength(1); cowCount++)
                {
                    if (matrix[rowCount, cowCount] == "B")
                    {
                        BunnyJump(helper, rowCount, cowCount);
                    }
                }
            }
            return helper;
        }

        private static void BunnyJump(string[,] helper, int rowCount, int cowCount)
        {
            ChangeCell(helper, rowCount - 1, cowCount);
            ChangeCell(helper, rowCount + 1, cowCount);
            ChangeCell(helper, rowCount, cowCount - 1);
            ChangeCell(helper, rowCount, cowCount + 1);
        }

        private static void ChangeCell(string[,] helper, int rowCount, int cowCount)
        {
            if (IsInside(helper, rowCount, cowCount))
            {
                helper[rowCount, cowCount] = "B";
            }
        }

        private static bool IsInside(string[,] helper, int rowCount, int cowCount)
        {
            return rowCount >= 0 && cowCount >= 0 && rowCount < helper.GetLength(0) && cowCount < helper.GetLength(1);
        }

        private static void MovePlayer(string command)
        {
            switch (command)
            {
                case "U":
                    playerRow--;
                    break;
                case "D":
                    playerRow++;
                    break;
                case "L":
                    playerCow--;
                    break;
                case "R":
                    playerCow++;
                    break;
            }
        }

        private static void FillMatrix(int rows, int cows, string[,] matrix)
        {
            for (int rowCount = 0; rowCount < rows; rowCount++)
            {
                var newRow = Console.ReadLine().ToCharArray();
                for (int cowCount = 0; cowCount < cows; cowCount++)
                {
                    var newItem = newRow[cowCount].ToString();
                    matrix[rowCount, cowCount] = newItem;
                    if (newItem == "P")
                    {
                        playerRow = rowCount;
                        playerCow = cowCount;
                        matrix[rowCount, cowCount] = ".";
                    }
                }
            }
        }
    }
}