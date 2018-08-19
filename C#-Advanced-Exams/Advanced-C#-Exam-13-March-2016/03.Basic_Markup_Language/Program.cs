using System;
using System.Text.RegularExpressions;

namespace Bacis_MarkUp_Language
{
	class Program
	{
		public static void Main(string[] args)
		{
			var pattern = "<\\s*(.*?)\\s*(value\\s*=\\s*\"([0-9]+)\"\\s*)?content\\s*=\\s*\"(.*?)\"\\s*/>";
			var count = 1;
			while (true) {
				var input = Console.ReadLine();
				if (input == "<stop/>") {
					break;
				}
				Match currentMatch = Regex.Match(input, pattern);
				if (currentMatch.Success) {
					var command = currentMatch.Groups[1].Value;
					if (command == "inverse") {
						var content = currentMatch.Groups[4].Value;
						string inversedText = InverseText(content);
						if (inversedText.Length > 0) {
							Console.WriteLine(count++ + ". " + inversedText);
						}
					} else if (command == "reverse") {
						var content = currentMatch.Groups[4].Value;
						if (content.Length > 0) {
							Console.Write(count++ + ". ");
							for (int i = content.Length - 1; i >= 0; i--) {
								Console.Write(content[i]);
							}
							Console.WriteLine();
						}
					} else if (command == "repeat") {
						var value = int.Parse(currentMatch.Groups[3].Value);
						var content = currentMatch.Groups[4].Value;
						for (int i = 0; i < value; i++) {
							Console.WriteLine(count++ + ". " + content);
						}
					}
				}
			}
			Console.ReadLine();
		}

		static string InverseText(string content)
		{
			var result = "";
			for (int i = 0; i < content.Length; i++) {
				var currentChar = content[i].ToString();
				if (currentChar.ToLower() == currentChar) {
					result += currentChar.ToUpper();
				} else {
					result += currentChar.ToLower();
				}
			}
			return result;
		}
	}
}