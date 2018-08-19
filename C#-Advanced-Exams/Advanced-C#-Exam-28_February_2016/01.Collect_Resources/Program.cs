using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Collect_Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(Console.ReadLine());
            var maxSum = 0;
            for (int i = 0; i < n; i++)
            {
                var collectIndex = new List<int>();
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var currentIndex = input[0];
                var steep = input[1];
                var currentSum = 0;
                while (true)
                {
                    if (collectIndex.IndexOf(currentIndex) != -1)
                    {
                        break;
                    }
                    collectIndex.Add(currentIndex);
                    var itemTokens = products[currentIndex].Split(new[] { "_" }, StringSplitOptions.None);
                    var itemName = itemTokens[0];
                    var itemQuantity = 1;
                    if (itemTokens.Count() > 1)
                    {
                        itemQuantity = int.Parse(itemTokens[1]);
                    }
                    if (itemName == "stone" || itemName == "gold" || itemName == "wood" || itemName == "food")
                    {
                        currentSum += itemQuantity;
                    }
                    currentIndex = (currentIndex + steep) % products.Count();
                }
                maxSum = Math.Max(maxSum, currentSum);
            }
            Console.WriteLine(maxSum);
        }
    }
}
