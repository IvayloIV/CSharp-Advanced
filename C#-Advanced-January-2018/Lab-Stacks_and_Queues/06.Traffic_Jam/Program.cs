using System;
using System.Collections.Generic;

namespace _06.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var passedCarsOnGreen = int.Parse(Console.ReadLine());
            var queueCars = new Queue<string>();
            var totalPassedCars = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    for (int i = 0; i < passedCarsOnGreen; i++)
                    {
                        if (queueCars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{queueCars.Dequeue()} passed!");
                        totalPassedCars++;
                    }
                }
                else
                {
                    queueCars.Enqueue(input);
                }
            }
            Console.WriteLine($"{totalPassedCars} cars passed the crossroads.");
        }
    }
}
