using System;

namespace DangerousFloor
{
	class Program
	{
		public static void Main(string[] args)
		{
			char[,] matrix = new char[8, 8];
			for (int i = 0; i < 8; i++) {
				var input = Console.ReadLine().Split(new[] {","},StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < 8; j++) {
					matrix[i, j] = char.Parse(input[j]);
				}
			}
			while (true) {
				var input = Console.ReadLine();
				if (input == "END")
				{
					break;
				}
				var tokens = input.Split(new[] {"-"},StringSplitOptions.RemoveEmptyEntries);
				var figure = tokens[0][0];
				var startRow = int.Parse(tokens[0][1].ToString());
				var startCow = int.Parse(tokens[0][2].ToString());
				var endRow = int.Parse(tokens[1][0].ToString());
				var endCow = int.Parse(tokens[1][1].ToString());
				
				if (matrix[startRow, startCow] != figure)
				{
					Console.WriteLine("There is no such a piece!");
				}
                else if (!ValidMove(startRow, startCow, endRow, endCow, figure, matrix))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if (!IsOutOfBoard(matrix, endCow, endRow))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    matrix[startRow, startCow] = 'x';
                    matrix[endRow, endCow] = figure;
                }
			}
		}

        private static bool IsOutOfBoard(char[,] matrix, int endCow, int endRow)
        {
            return endCow >= 0 && endRow >= 0 && endRow < matrix.GetLength(0) && endCow < matrix.GetLength(1);
        }

        static bool ValidMove(int startRow, int startCow, int endRow, int endCow, char figure, char[,] matrix)
		{
            if (figure == 'K')
            {
                return CheckSquare(startRow, startCow, endRow, endCow);
            }
            else if (figure == 'R')
            {
                return CheckVerticalAndHorizontal(startRow, startCow, endRow, endCow);
            }
            else if (figure == 'B')
            {
                return CheckDiagonals(startRow, startCow, endRow, endCow);
            }
            else if (figure == 'Q')
            {
                return CheckSquare(startRow, startCow, endRow, endCow) ||
                    CheckVerticalAndHorizontal(startRow, startCow, endRow, endCow) ||
                    CheckDiagonals(startRow, startCow, endRow, endCow);
            }
            else if (figure == 'P')
            {
                return startRow - 1 == endRow && startCow == endCow;
            }
            throw new Exception();
		}

        private static bool CheckDiagonals(int startRow, int startCow, int endRow, int endCow)
        {
            var rowSquare = Math.Abs(startRow - endRow);
            var cowSquare = Math.Abs(startCow - endCow);
            return rowSquare == cowSquare;
        }

        private static bool CheckVerticalAndHorizontal(int startRow, int startCow, int endRow, int endCow)
        {
            return startRow == endRow || startCow == endCow;
        }

        private static bool CheckSquare(int startRow, int startCow, int endRow, int endCow)
        {
            return endRow >= startRow - 1 && endRow <= startRow + 1
                        && endCow >= startCow - 1 && endCow <= startCow + 1;
        }
    }
}