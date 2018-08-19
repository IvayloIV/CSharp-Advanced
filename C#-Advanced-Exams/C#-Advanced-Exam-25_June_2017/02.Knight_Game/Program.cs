using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int cow = 0; cow < matrix.GetLength(1); cow++)
                {
                    matrix[row, cow] = input[cow];
                }
            }

            var counter = 0;
            while(true)
            {
                var book = new Dictionary<string, int>();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int cow = 0; cow < matrix.GetLength(1); cow++)
                    {
                        if (matrix[row, cow] == 'K')
                        {
                            CheckPositon(row, cow, matrix, book);
                        }
                    }
                }
                book = book.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, b => b.Value);
                var isEnd = true;
                foreach (var item in book)
                {
                    if (item.Value != 0)
                    {
                        var tokens = item.Key.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        matrix[tokens[0], tokens[1]] = '0';
                        isEnd = false;
                        counter++;
                    }
                    break;
                }
                if (isEnd)
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }

        private static void CheckPositon(int row, int cow, char[,] matrix, Dictionary<string, int> book)
        {
            var position = $"{row}-{cow}";
            if (!book.ContainsKey(position))
            {
                book[position] = 0;
            }
            IncreaseSum(book, matrix, row - 2, cow - 1, position);
            IncreaseSum(book, matrix, row - 2, cow + 1, position);
            IncreaseSum(book, matrix, row - 1, cow + 2, position);
            IncreaseSum(book, matrix, row + 1, cow + 2, position);
            IncreaseSum(book, matrix, row + 2, cow - 1, position);
            IncreaseSum(book, matrix, row + 2, cow + 1, position);
            IncreaseSum(book, matrix, row - 1, cow - 2, position);
            IncreaseSum(book, matrix, row + 1, cow - 2, position);
        }

        private static void IncreaseSum(Dictionary<string, int> book, char[,] matrix, int row, int cow, string position)
        {
            if (IsInside(row, cow, matrix) && matrix[row, cow] == 'K')
            {
                book[position]++;
            }
        }

        private static bool IsInside(int row, int cow, char[,] matrix)
        {
            return row >= 0 && cow >= 0 && row < matrix.GetLength(0) && cow < matrix.GetLength(1); 
        }
    }
}
