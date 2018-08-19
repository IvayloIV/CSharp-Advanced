using System;
using System.Collections.Generic;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var helper = new Queue<long>();
            queue.Enqueue(n);
            var count = 0;
            while (helper.Count < 50)
            {
                count++;
                var currentNum = queue.Dequeue();
                helper.Enqueue(currentNum);
                queue.Enqueue(currentNum + 1);
                queue.Enqueue(2 * currentNum + 1);
                queue.Enqueue(currentNum + 2);
            }
            while (helper.Count > 0)
            {
                Console.Write(helper.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }
}