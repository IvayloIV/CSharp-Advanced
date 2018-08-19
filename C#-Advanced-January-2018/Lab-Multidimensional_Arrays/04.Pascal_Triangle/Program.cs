using System;

namespace _04.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            long[][] jaggedArr = new long[n][];
            for (int heigth = 1; heigth <= n; heigth++)
            {
                var newRow = new long[heigth];
                newRow[0] = 1;
                newRow[heigth - 1] = 1;
                for (int middleCow = 1; middleCow <= heigth - 2; middleCow++)
                {
                    newRow[middleCow] = jaggedArr[heigth - 2][middleCow - 1] + jaggedArr[heigth - 2][middleCow];
                }
                jaggedArr[heigth - 1] = newRow;
            }
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int cow = 0; cow < jaggedArr[row].Length; cow++)
                {
                    Console.Write(jaggedArr[row][cow] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
