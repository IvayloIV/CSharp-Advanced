using System;
using System.Linq;

namespace _11.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cows = input[1];
            byte[][] matrix = new byte[rows][];
            while (true)
            {
                var token = Console.ReadLine();
                if (token == "stop")
                {
                    break;
                }
                var tokens = token.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var startRow = tokens[0];
                var parkRow = tokens[1];
                var partCow = tokens[2];
                var moved = 0;
                if (matrix[parkRow] == null)
                {
                    matrix[parkRow] = new byte[cows];
                }
                moved += Math.Abs(startRow - parkRow) + 1;
                moved += partCow;
                var isFindPlace = false;
                if (matrix[parkRow][partCow] == 0)
                {
                    matrix[parkRow][partCow] = 1;
                    isFindPlace = true;
                }
                var leftPosition = partCow;
                var rigthPosition = partCow;
                var steps = 0;
                while (!isFindPlace)
                {
                    if (leftPosition <= 1 && rigthPosition > matrix[parkRow].Length - 1)
                    {
                        break;
                    }
                    steps++;
                    leftPosition--;
                    if (leftPosition >= 1 && matrix[parkRow][leftPosition] == 0)
                    {
                        matrix[parkRow][leftPosition] = 1;
                        isFindPlace = true;
                        moved -= steps;
                        break;
                    }
                    rigthPosition++;
                    if (rigthPosition < matrix[parkRow].Length && matrix[parkRow][rigthPosition] == 0)
                    {
                        matrix[parkRow][rigthPosition] = 1;
                        isFindPlace = true;
                        moved += steps;
                        break;
                    }
                }
                if (isFindPlace)
                {
                    Console.WriteLine(moved);
                }
                else
                {
                    Console.WriteLine($"Row {parkRow} full");
                }
            }
        }
    }
}