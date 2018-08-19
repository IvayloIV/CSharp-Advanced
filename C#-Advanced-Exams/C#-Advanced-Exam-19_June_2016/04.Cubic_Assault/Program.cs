using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicAssault
{
	class Program
	{
		public static void Main(string[] args)
		{
			var book = new Dictionary<string, Dictionary<string, long>>();
			while (true) {
				var input = Console.ReadLine();
				if (input == "Count em all") 
				{
					break;
				}
				var tokens = input.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
				if (!book.ContainsKey(tokens[0])) 
				{
					book[tokens[0]] = new Dictionary<string, long>();
					book[tokens[0]]["Red"] = 0l;
					book[tokens[0]]["Black"] = 0l;
					book[tokens[0]]["Green"] = 0l;
				}
				book[tokens[0]][tokens[1]] += long.Parse(tokens[2]);
				
				while (book[tokens[0]]["Green"] >= 1000000) {
					book[tokens[0]]["Green"] -= 1000000;
					book[tokens[0]]["Red"]++;
				}
				while (book[tokens[0]]["Red"] >= 1000000) {
					book[tokens[0]]["Red"] -= 1000000;
					book[tokens[0]]["Black"]++;
				}
			}
			foreach (var pear in book.OrderByDescending(a => a.Value["Black"]).ThenBy(a => a.Key.Length)
			         .ThenBy(a => a.Key)) {
				Console.WriteLine(pear.Key);
				foreach(var innerPair in pear.Value.OrderByDescending(a => a.Value).ThenBy(a => a.Key)) {
					Console.WriteLine("-> " + innerPair.Key +" : " + innerPair.Value);
				}
			}
		}
	}
}