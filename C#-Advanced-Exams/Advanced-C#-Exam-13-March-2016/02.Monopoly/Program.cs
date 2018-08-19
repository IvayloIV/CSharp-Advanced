using System;
using System.Linq;

namespace Monopoly
{
	class Program
	{
		public static void Main(string[] args)
		{
			var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
			char[,] matrix = new char[tokens[0], tokens[1]];
			for (int rowCount = 0; rowCount < tokens[0]; rowCount++) {
				var newRow = Console.ReadLine();
				for (int cowCount = 0; cowCount < tokens[1]; cowCount++) {
					matrix[rowCount, cowCount] = newRow[cowCount];
				}
			}
			
			var turn = 0;
			var winPerTurn = 0;
			var money = 50;
			var isReversedRow = false;
			var hotelCount = 0;
			for (int rowCount = 0; rowCount < matrix.GetLength(0); rowCount++) {
				for (int cowCount = 0; cowCount < matrix.GetLength(1); cowCount++) {
					var innerCow = isReversedRow ? matrix.GetLength(1) - 1 - cowCount : cowCount;
					var currentElement = matrix[rowCount, innerCow];
					if (currentElement == 'H')
					{
						Console.WriteLine("Bought a hotel for " + money + ". Total hotels: " + ++hotelCount + ".");
						winPerTurn += 10;
						money = 0;
					} else if (currentElement == 'J') 
					{
						Console.WriteLine("Gone to jail at turn " + turn + ".");
						for (int i = 0; i < 2; i++) {
							turn++;
							money+= winPerTurn;
						}
					} else if (currentElement == 'S') 
					{
						var product = (rowCount + 1) * (innerCow + 1);
						if (product > money) {
							product = money;
						}
						Console.WriteLine("Spent " + product + " money at the shop.");
						money -= product;
					}
					turn++;
					money += winPerTurn;
				}
				isReversedRow = !isReversedRow;
			}
			Console.WriteLine("Turns " + turn);
			Console.WriteLine("Money " + money);
			Console.ReadLine();
		}
	}
}