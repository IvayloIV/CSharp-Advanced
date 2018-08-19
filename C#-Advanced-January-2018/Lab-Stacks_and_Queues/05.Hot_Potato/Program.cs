using System;
using System.Collections.Generic;

namespace _05.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ');
            var hotToss = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            foreach (var name in names)
            {
                queue.Enqueue(name);
            }
            while (queue.Count > 1)
            {
                for (int i = 1; i < hotToss; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }
            Console.WriteLine("Last is "+ queue.Peek());
        }
    }
}
