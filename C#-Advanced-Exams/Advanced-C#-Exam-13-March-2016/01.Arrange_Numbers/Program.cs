using System;
using System.Linq;
using System.Collections.Generic;

namespace Arrange_Integers
{
    class Numbers {
        public int Number { get; set; }
        public string NumberWithWords { get; set; }
    }
	class Program
	{
		public static void Main(string[] args)
		{
			var nums = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
			var book = new List<Numbers>();
			
			foreach (var num in nums) {
				var letters = new List<string>();
				foreach (var letter in num) {
					letters.Add(GetAlhaLetter(letter));
				}
				var newNumber = new Numbers();
                newNumber.Number = int.Parse(num);
                newNumber.NumberWithWords = String.Join("-", letters);
                book.Add(newNumber);
			}
			
			var result = new List<int>();
			foreach (var element in book.OrderBy(a => a.NumberWithWords)) {
				result.Add(element.Number);
			}
			Console.WriteLine(String.Join(", ", result));
		}

		static string GetAlhaLetter(char letter)
		{
			switch (letter) {
				case '0':
					return "zero";
				case '1':
					return "one";
				case '2':
					return "two";
				case '3':
					return "three";
				case '4':
					return "four";
				case '5':
					return "five";
				case '6':
					return "six";
				case '7':
					return "seven";
				case '8':
					return "eight";
				case '9':
					return "nine";
			}
			throw new Exception();
		}
	}
}