using System;
using System.Linq;
using System.Collections.Generic;

namespace Sneaking
{
	class Program
	{
		public static void Main(string[] args)
		{
			var rows = int.Parse(Console.ReadLine());
			char[][] jagged = new char[rows][];
			var samRow = 0;
			var samCow = 0;
			for (int i = 0; i < rows; i++) {
				var newRow = Console.ReadLine();
				jagged[i] = newRow.ToCharArray();
				var indexOfSam = newRow.IndexOf('S');
				if (indexOfSam != -1)
				{
					samRow = i;
					samCow = indexOfSam;
				}
			}
			var commands = Console.ReadLine().ToCharArray();
			foreach (var command in commands) {
				MoveEnemies(jagged);
				bool isKilled = SearchSam(samRow, samCow, jagged);
				if (isKilled)
				{
					jagged[samRow][samCow] = 'X';
					Console.WriteLine("Sam died at " + samRow + ", " + samCow);
					break;
				}
				if (command != 'W')
				{
					jagged[samRow][samCow] = '.';
					if (command == 'R')
					{
						samCow++;
					} else if(command == 'L')
					{
						samCow--;
					} else if (command == 'U')
					{
						samRow--;
					} else if (command == 'D')
					{
						samRow++;
					}
					jagged[samRow][samCow] = 'S';
					var isKillNiko = false;
					for (int cow = 0; cow < jagged[samRow].Length; cow++) {
						if (jagged[samRow][cow] == 'N') 
						{
							jagged[samRow][cow] = 'X';
							isKillNiko = true;
						}
					}
					if (isKillNiko)
					{
						Console.WriteLine("Nikoladze killed!");
						break;
					}
				}
			}
			PrintJagged(jagged);
			Console.ReadLine();
		}

		static void PrintJagged(char[][] jagged)
		{
			for (int row = 0; row < jagged.Length; row++) {
				for (int cow = 0; cow < jagged[row].Length; cow++) {
					Console.Write(jagged[row][cow]);
				}
				Console.WriteLine();
			}
		}
		
		static void MoveEnemies(char[][] jagged)
		{
			for (int rowCount = 0; rowCount < jagged.Length; rowCount++) {
				for (int cowCount = 0; cowCount < jagged[rowCount].Length; cowCount++) {
					if (jagged[rowCount][cowCount] == 'b') 
					{
						if (cowCount == jagged[rowCount].Length - 1) 
						{
							jagged[rowCount][cowCount] = 'd';
						} else 
						{
							jagged[rowCount][cowCount] = '.';
							jagged[rowCount][cowCount + 1] = 'b';
							cowCount++;
						}
					} 
					else if (jagged[rowCount][cowCount] == 'd')
					{
						if (cowCount == 0) 
						{
							jagged[rowCount][cowCount] = 'b';
						} else 
						{
							jagged[rowCount][cowCount] = '.';
							jagged[rowCount][cowCount - 1] = 'd';
							cowCount--;
						}						
					}
				}
			}
		}
		
		static bool SearchSam(int samRow, int samCow, char[][] jagged)
		{
			for (int cowCount = 0; cowCount < jagged[samRow].Length; cowCount++) {
				if (jagged[samRow][cowCount] == 'b' && cowCount < samCow) 
				{
					return true;
				}
				else if (jagged[samRow][cowCount] == 'd' && cowCount > samCow) 
				{
					return true;
				}
			}
			return false;
		}
	}
}