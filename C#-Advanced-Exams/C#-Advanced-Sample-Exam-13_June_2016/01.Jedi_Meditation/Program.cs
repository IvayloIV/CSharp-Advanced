using System;
using System.Text;

namespace _01.Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var masterJedi = new StringBuilder();
            var knightJedi = new StringBuilder();
            var padawanJedi = new StringBuilder();
            var toshoAndSam = new StringBuilder();
            var isHavingYoda = false;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                isHavingYoda = Prosoccer(masterJedi, knightJedi, padawanJedi, toshoAndSam, isHavingYoda, input);
            }
            Console.WriteLine(isHavingYoda ? $"{masterJedi}{knightJedi}{toshoAndSam}{padawanJedi}" : 
            $"{toshoAndSam}{masterJedi}{knightJedi}{padawanJedi}");
        }

        private static bool Prosoccer(StringBuilder masterJedi, 
            StringBuilder knightJedi, 
            StringBuilder padawanJedi, 
            StringBuilder toshoAndSam, 
            bool isHavingYoda, 
            string[] input)
        {
            for (int k = 0; k < input.Length; k++)
            {
                var type = input[k][0];
                switch (type)
                {
                    case 'm':
                        masterJedi.Append(input[k] + " ");
                        break;
                    case 'k':
                        knightJedi.Append(input[k] + " ");
                        break;
                    case 'p':
                        padawanJedi.Append(input[k] + " ");
                        break;
                    case 'y':
                        isHavingYoda = true;
                        break;
                    default:
                        toshoAndSam.Append(input[k] + " ");
                        break;
                }
            }

            return isHavingYoda;
        }
    }
}
