using System;
using System.Linq;
using System.Collections.Generic;

namespace Key_Revolver
{
	class Program
	{
		public static void Main(string[] args)
		{
			var bulletPrice = int.Parse(Console.ReadLine());
			var gunBarrel = int.Parse(Console.ReadLine());
			var bullets = new Stack<int>(Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
			var locks = new Queue<int>(Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
			var intelligence = int.Parse(Console.ReadLine());
			
			var shots = 0;
			while (bullets.Count > 0 && locks.Count > 0) {
				var currentBullet = bullets.Pop();
				var currentLock = locks.Peek();
				if (currentLock >= currentBullet) 
				{
					locks.Dequeue();
					Console.WriteLine("Bang!");
				} else 
				{
					Console.WriteLine("Ping!");
				}
				if (++shots % gunBarrel == 0 && bullets.Count > 0) 
				{
					Console.WriteLine("Reloading!");
				}
			}
			if (locks.Count == 0)
			{
				var price = shots * bulletPrice;
				var earned = intelligence - price;
				Console.WriteLine(bullets.Count + " bullets left. Earned $" + earned);
			} else 
			{
				Console.WriteLine("Couldn't get through. Locks left: " + locks.Count);
			}
			Console.ReadLine();
		}
	}
}