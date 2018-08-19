using System;
using System.Linq;

namespace _02.Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            var rows = int.Parse(tokens[0]);
            var cows = int.Parse(tokens[1]);
            int[][] jagged = new int[rows][];
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                var innerTokens = input.Split().Select(int.Parse).ToList();
                var z = innerTokens[0];
                var x = innerTokens[1];
                var y = innerTokens[2];
                var steeps = Math.Abs(z - x) + 1 + y;
                var isFindPlace = true;
                if (jagged[x] == null)
                {
                    jagged[x] = new int[cows];
                }
                if (jagged[x][y] == 0)
                {
                    jagged[x][y] = 1;
                }
                else
                {
                    var move = 1;
                    while (true)
                    {
                        var leftMove = y - move;
                        var rightMove = y + move;
                        if (leftMove < 1 && rightMove >= jagged[x].Length)
                        {
                            isFindPlace = false;
                            break;
                        }
                        if (leftMove >= 1 && jagged[x][leftMove] == 0)
                        {
                            jagged[x][leftMove] = 1;
                            steeps -= move;
                            break;
                        }
                        else if (rightMove < jagged[x].Length && jagged[x][rightMove] == 0)
                        {
                            jagged[x][rightMove] = 1;
                            steeps += move;
                            break;
                        }
                        move++;
                    }
                }

                if (isFindPlace)
                {
                    Console.WriteLine(steeps);
                } else
                {
                    Console.WriteLine($"Row {x} full");
                }
            }
        }
    }
}