using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();
            var currentCapacity = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Bunker Revision")
                {
                    break;
                }
                var tokens = input.Split();
                foreach (var token in tokens)
                {
                    var isPass = int.TryParse(token, out int num);
                    if (!isPass)
                    {
                        bunkers.Enqueue(token);
                    }
                    else
                    {
                        if (currentCapacity + num <= maxCapacity)
                        {
                            weapons.Enqueue(num);
                            currentCapacity += num;
                        }
                        else if (bunkers.Count > 1 && currentCapacity + num > maxCapacity)
                        {
                            if (currentCapacity == 0)
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine(bunkers.Dequeue() + " -> " + String.Join(", ", weapons.ToList()));
                                currentCapacity = 0;
                            }
                            weapons = new Queue<int>();
                            if (currentCapacity + num <= maxCapacity)
                            {
                                weapons.Enqueue(num);
                                currentCapacity += num;
                            }
                        }
                        else if (bunkers.Count == 1 && maxCapacity >= num)
                        {
                            while (currentCapacity + num > maxCapacity)
                            {
                                currentCapacity -= weapons.Dequeue();
                            }
                            currentCapacity += num;
                            weapons.Enqueue(num);
                        }
                    }
                }
            }
        }
    }
}