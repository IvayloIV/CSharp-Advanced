using System;
using System.Linq;

namespace _02.Jedi_Galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var rows = input[0];
            var cows = input[1];
            var count = 0;
            int[,] matrix = new int[rows, cows];
            for (int rowsCount = 0; rowsCount < matrix.GetLength(0); rowsCount++)
            {
                for (int cowsCount = 0; cowsCount < matrix.GetLength(1); cowsCount++)
                {
                    matrix[rowsCount, cowsCount] = count++;
                }
            }
            var starsSum = 0l;
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Let the Force be with you")
                {
                    break;
                }
                var ivoTokens = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var enemyTokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var ivoRow = ivoTokens[0];
                var ivoCow = ivoTokens[1];
                var enemyRow = enemyTokens[0];
                var enemyCow = enemyTokens[1];

                var diffIvoRows = ivoRow - (matrix.GetLength(0) - 1);
                if (diffIvoRows > 0)
                {
                    ivoRow -= diffIvoRows;
                    ivoCow += diffIvoRows;
                }
                var diffEnemyRows = enemyRow - (matrix.GetLength(0) - 1);
                if (diffEnemyRows > 0)
                {
                    enemyRow -= diffEnemyRows;
                    enemyCow -= diffEnemyRows;
                }
                while (enemyRow >= 0 && enemyCow >= 0)
                {
                    if (IsInside(enemyRow, enemyCow, matrix))
                    {
                        matrix[enemyRow, enemyCow] = 0;
                    }
                    enemyRow--;
                    enemyCow--;
                }
                while (ivoRow >= 0 && ivoCow < matrix.GetLength(1))
                {
                    if (IsInside(ivoRow, ivoCow, matrix))
                    {
                        starsSum += matrix[ivoRow, ivoCow];
                    }
                    ivoRow--;
                    ivoCow++;
                }
            }
            Console.WriteLine(starsSum);
        }

        private static bool IsInside(int ivoRow, int ivoCow, int[,] matrix)
        {
            return ivoRow < matrix.GetLength(0) && ivoCow < matrix.GetLength(1) && ivoRow >= 0 && ivoCow >= 0;
        }
    }
}