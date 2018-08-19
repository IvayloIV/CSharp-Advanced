using System;
using System.Collections.Generic;

namespace _01.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLight = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());
            var passedCars = 0;
            var carsQueue = new Queue<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    var currentSeconds = greenLight;
                    var currentCar = new Queue<char>();
                    var currentCarName = "";
                    while (currentSeconds-- > 0 && (carsQueue.Count != 0 || currentCar.Count != 0))
                    {
                        if (currentCar.Count == 0)
                        {
                            passedCars++;
                            var car = carsQueue.Dequeue();
                            currentCarName = car;
                            for (int i = 0; i < car.Length; i++)
                            {
                                currentCar.Enqueue(car[i]);
                            }
                        }
                        currentCar.Dequeue();
                    }
                    if (currentCar.Count > 0)
                    {
                        var bonusSecond = freeWindow;
                        while (bonusSecond-- > 0 && currentCar.Count != 0)
                        {
                            currentCar.Dequeue();
                        }
                        if (currentCar.Count > 0)
                        {
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{currentCarName} was hit at {currentCar.Dequeue()}.");
                            return;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
