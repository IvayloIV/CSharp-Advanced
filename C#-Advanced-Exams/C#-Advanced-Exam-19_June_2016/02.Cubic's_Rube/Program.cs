using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = int.Parse(Console.ReadLine());
            int[,,] cube = new int[dimensions, dimensions, dimensions];
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Analyze")
                {
                    break;
                }
                var tokens = input.Split().Select(int.Parse).ToList();
                var point1 = tokens[0];
                var point2 = tokens[1];
                var point3 = tokens[2];
                if (IsInside(point1, point2, point3, cube) && cube[point1, point2, point3] != tokens[3])
                {
                    cube[point1, point2, point3] = tokens[3];
                }
            }
            var emptySells = 0;
            long sum = 0;
            for (int firstD = 0; firstD < cube.GetLength(0); firstD++)
            {
                for (int secondD = 0; secondD < cube.GetLength(1); secondD++)
                {
                    for (int thirdD = 0; thirdD < cube.GetLength(2); thirdD++)
                    {
                        if (cube[firstD, secondD, thirdD] == 0)
                        {
                            emptySells++;
                        }
                        sum += cube[firstD, secondD, thirdD];
                    }
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(emptySells);
        }

        private static bool IsInside(int point1, int point2, int point3, int[,,] cube)
        {
            return point1 >= 0 && point2 >= 0 && point3 >= 0 && point1 < cube.GetLength(0)
                && point2 < cube.GetLength(1) && point3 < cube.GetLength(2);
        }
    }
}