using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    public class PoisonousPlants
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var indexes = new Stack<int>();
            indexes.Push(0);
            var days = new int[n];

            for (int i = 1; i < n; i++)
            {
                var maxDay = 0;
                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDay = Math.Max(maxDay, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDay + 1;
                }

                indexes.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}