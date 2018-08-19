using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{
	class Program
	{
		public static void Main(string[] args)
		{
			var capacity = long.Parse(Console.ReadLine());
			var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
			var book = new Dictionary<string, Dictionary<string, long>>();
			book["Gold"] = new Dictionary<string, long>();
			book["Gem"] = new Dictionary<string, long>();
			book["Cash"] = new Dictionary<string, long>();
			long gold = 0;
			long gem = 0;
			long cash = 0;
			long currentCapacity = 0;
			for (int i = 0; i < tokens.Length; i += 2) {
				var type = tokens[i];
				var quantity = long.Parse(tokens[i + 1]);
				if (currentCapacity + quantity > capacity) 
				{
					continue;
				}
				if (type.Length == 3)
				{
					if (gold >= gem && gem >= cash + quantity) {
						cash += quantity;
						if (!book["Cash"].ContainsKey(type)) 
						{
							book["Cash"][type] = 0;
						}
						book["Cash"][type] += quantity;
						currentCapacity += quantity;
					}
				} else if (type.ToLower().EndsWith("gem") && type.Length >= 4)
				{
					if (gold >= gem + quantity && gem + quantity >= cash) 
					{
						gem +=quantity;
						if (!book["Gem"].ContainsKey(type)) 
						{
							book["Gem"][type] = 0;
						}
						book["Gem"][type] += quantity;
						currentCapacity += quantity;
					}
				} else if (type.ToLower() == "gold") 
				{
					if (gold + quantity >= gem && gem >= cash) 
					{
						gold +=quantity;
						if (!book["Gold"].ContainsKey(type)) 
						{
							book["Gold"][type] = 0;
						}
						book["Gold"][type] += quantity;
						currentCapacity += quantity;
					}
				}
			}
			foreach (var item in book.OrderByDescending(a => a.Value.Sum(b => b.Value))) {
				var totalSum = item.Value.Sum(b => b.Value);
                var countProducts = item.Value.Count();
				if (countProducts == 0) {
					break;
				}
				Console.WriteLine("<" + item.Key + "> $" + totalSum);
				foreach (var element in item.Value.OrderByDescending(a => a.Key).ThenBy(b => b.Value)) {
					Console.WriteLine("##" + element.Key + " - " + element.Value);
				}
			}
		}
	}
}