using System;
using System.Linq;

namespace _03.Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numsCountByRow = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                numsCountByRow[Math.Abs(nums[i] % 3)]++;
            }
            int[][] jaggedArr = new int[3][];
            for (int i = 0; i < numsCountByRow.Length; i++)
            {
                jaggedArr[i] = new int[numsCountByRow[i]];
            }
            int[] countLenth = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i] % 3);
                jaggedArr[index][countLenth[index]] = nums[i];
                countLenth[index]++;
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
