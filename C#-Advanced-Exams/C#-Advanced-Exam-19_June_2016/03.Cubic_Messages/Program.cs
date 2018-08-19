using System;
using System.Text.RegularExpressions;

namespace _03.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Over!")
                {
                    break;
                }
                var num = int.Parse(Console.ReadLine());
                var exec = Regex.Match(input, @"^([0-9]+)([A-Za-z]{" + num + @"})([^A-Za-z]*)$");
                if (exec.Success)
                {
                    var totalGroups = exec.Groups[1].Value + exec.Groups[3].Value;
                    var text = exec.Groups[2].Value;
                    var result = "";
                    for (int i = 0; i < totalGroups.Length; i++)
                    {
                        var isNum = int.TryParse(totalGroups[i].ToString(), out int index);
                        if (isNum)
                        {
                            if (index < text.Length)
                            {
                                result += text[index];
                            }
                            else
                            {
                                result += " ";
                            }
                        }
                    }
                    Console.WriteLine($"{text} == {result}");
                }
            }
        }
    }
}
