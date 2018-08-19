using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var maxLenght = int.MinValue;
            for (int steps = 1; steps < nums.Count; steps++)
            {
                for (int stpNode = 0; stpNode < nums.Count; stpNode++)
                {
                    var currentIndex = stpNode;
                    var nextIndex = (stpNode + steps) % nums.Count;
                    var currentLength = 1;

                    while (nums[nextIndex] > nums[currentIndex])
                    {
                        currentLength++;
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + steps) % nums.Count;
                    }
                    if (maxLenght < currentLength)
                    {
                        maxLenght = currentLength;
                    }
                }
            }
            Console.WriteLine(maxLenght);
        }
    }
}
