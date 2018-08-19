using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CryptoBlockchein
{
	class Program
	{
		public static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var text = "";
			for (int i = 0; i < n; i++) {
				text += Console.ReadLine();
			}
			var pattern = @"(\{|\[)(?:.*?)([0-9]{3,})(?:.*?)(\}|\])";
			var totalMatches = Regex.Matches(text, pattern);
			var result = "";
			foreach (Match match in totalMatches) {
				var openBrackets = match.Groups[1].Value;
				var numbers = match.Groups[2].Value;
				var closeBrackets = match.Groups[3].Value;
				if (((openBrackets == "{" && closeBrackets == "}") 
				     || (openBrackets == "[" && closeBrackets == "]")) && numbers.Length % 3 == 0) 
				{
					var lengthOfMatch = match.Length;
					for (int i = 0; i < numbers.Length; i += 3) {
						result += (char)(int.Parse(numbers.Substring(i, 3)) - lengthOfMatch);
					}
				}
			}
			Console.WriteLine(result);
			Console.ReadLine();
		}
	}
}