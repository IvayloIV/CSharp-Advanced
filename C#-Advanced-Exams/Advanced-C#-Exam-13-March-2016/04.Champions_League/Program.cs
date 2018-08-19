using System;
using System.Collections.Generic;
using System.Linq;

namespace ChampionsLeague
{
	class Program
	{
		class Result {
			public int Wins { get; set; }
			public List<string> Opponents { get; set; }
		}
		
		public static void Main(string[] args)
		{
			var book = new Dictionary<string, Result>();
			while (true) {
				var input = Console.ReadLine();
				if (input == "stop") {
					break;
				}
				var tokens = input.Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries);
				var firstTeamName = tokens[0];
				var secondTeamName = tokens[1];
				var firstMatchResult = tokens[2].Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
				var secondMatchResult = tokens[3].Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
				CreateTeam(book, firstTeamName);
				CreateTeam(book, secondTeamName);
				
				book[firstTeamName].Opponents.Add(secondTeamName);
				book[secondTeamName].Opponents.Add(firstTeamName);
				
				var firstTeamResult = firstMatchResult[0] + secondMatchResult[1];
				var secondTeamResult = secondMatchResult[0] + firstMatchResult[1];
				if (firstTeamResult > secondTeamResult) {
					book[firstTeamName].Wins++;
				} else if (firstTeamResult < secondTeamResult) {
					book[secondTeamName].Wins++;
				} else {
					var firstTeamGoalAway = secondMatchResult[1];
					var secondTeamGoalAway = firstMatchResult[1];
					if (firstTeamGoalAway > secondTeamGoalAway) {
						book[firstTeamName].Wins++;
					} else {
						book[secondTeamName].Wins++;
					}
				}
			}
			PrintResult(book);
			Console.ReadLine();
		}

		static void PrintResult(Dictionary<string, Result> book)
		{
			foreach (var pair in book.OrderByDescending(a => a.Value.Wins).ThenBy(a => a.Key)) {
				Console.WriteLine(pair.Key);
				Console.WriteLine("- Wins: " + pair.Value.Wins);
				Console.WriteLine("- Opponents: " + String.Join(", ", pair.Value.Opponents.OrderBy(a => a)));
			}
		}
		static void CreateTeam(Dictionary<string, Result> book, string team)
		{
			if (!book.ContainsKey(team)) {
				book[team] = new Result();
				book[team].Wins = 0;
				book[team].Opponents = new List<string>();
			}
		}
	}
}