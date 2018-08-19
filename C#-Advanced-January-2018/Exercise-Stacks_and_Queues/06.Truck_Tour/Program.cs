using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
            for (int i = 0; i < n - 1; i++)
            {
                var isPass = true;
                var fuel = 0;
                for (int j = 0; j < n; j++)
                {
                    var currentPath = queue.Dequeue();
                    fuel += currentPath[0] - currentPath[1];
                    queue.Enqueue(currentPath);
                    if (fuel < 0)
                    {
                        i += j;
                        isPass = false;
                        break;
                    }
                }
                if (isPass)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}
