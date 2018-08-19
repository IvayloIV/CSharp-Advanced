using System;
using System.Collections.Generic;
using System.Linq;

namespace Hit_List
{
	class Program
	{
		public static void Main(string[] args)
		{
			var book = new Dictionary<string, Dictionary<string, string>>();
			var targetLength = int.Parse(Console.ReadLine());
			while (true) {
				var input = Console.ReadLine();
				if (input == "end transmissions")
				{
					break;
				}
				var tokens = input.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
				var name = tokens[0];
				var attrs = tokens[1].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
				if (!book.ContainsKey(name))
				{
					book[name] = new Dictionary<string, string>();
				}
				foreach (var attr in attrs) {
					var innerToken = attr.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
					var key = innerToken[0];
					var value = innerToken[1];
					book[name][key] = value;
				}
			}
			var killedPerson = Console.ReadLine().Split()[1];
			Console.WriteLine("Info on " + killedPerson + ":");
			var sumLength = 0;
			foreach (var item in book[killedPerson].OrderBy(a => a.Key)) {
				Console.WriteLine("---" + item.Key + ": " + item.Value);
				sumLength += item.Key.Length + item.Value.Length;
			}
			Console.WriteLine("Info index: " + sumLength);
			if (targetLength <= sumLength) 
			{
				Console.WriteLine("Proceed");
			} else 
			{
				Console.WriteLine("Need " + (targetLength - sumLength) + " more info.");
			}
			Console.ReadLine();
		}
	}
}