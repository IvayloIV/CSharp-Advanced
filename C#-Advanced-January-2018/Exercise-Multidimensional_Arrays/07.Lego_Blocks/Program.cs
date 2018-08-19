using System;
using System.Linq;

namespace _07.Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[][] jaggedLeftArr = new int[n][];
            int[][] jaggedRightArr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jaggedLeftArr[i] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                jaggedRightArr[i] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Reverse().Select(int.Parse).ToArray();
            }
            var unionJaggedArr = new int[n][];
            var ceils = 0;
            for (int i = 0; i < n; i++)
            {
                var newArr = jaggedLeftArr[i].Concat(jaggedRightArr[i]).ToArray();
                unionJaggedArr[i] = newArr;
                ceils += newArr.Length;
            }
            var isEqual = true;
            var lengthInJagged = unionJaggedArr[0].Length;
            for (int rows = 1; rows < unionJaggedArr.Length; rows++)
            {
                if (lengthInJagged != unionJaggedArr[rows].Length)
                {
                    isEqual = false;
                    break;
                }
            }
            if (isEqual)
            {
                for (int rows = 0; rows < unionJaggedArr.Length; rows++)
                {
                    Console.WriteLine($"[{String.Join(", ", unionJaggedArr[rows])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {ceils}");
            }
        }
    }
}
