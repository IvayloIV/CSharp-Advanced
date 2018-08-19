using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            var genre = Console.ReadLine();
            var typeMovie = Console.ReadLine();
            var moviesDurationSec = 0;
            var book = new Dictionary<string, int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "POPCORN!")
                {
                    break;
                }
                var tokens = input.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var currentGenre = tokens[1];
                var timeTokens = tokens[2].Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var seconds = (timeTokens[0] * 3600) + (timeTokens[1] * 60) + timeTokens[2];
                moviesDurationSec += seconds;
                if (currentGenre != genre)
                {
                    continue;
                }
                if (!book.ContainsKey(name))
                {
                    book[name] = 0;
                }
                book[name] += seconds;
            }

            if (typeMovie == "Short")
            {
                book = book.OrderBy(a => a.Value).ThenBy(a => a.Key).ToDictionary(a => a.Key, b => b.Value);
            }
            else
            {
                book = book.OrderByDescending(a => a.Value).ThenBy(a => a.Key).ToDictionary(a => a.Key, b => b.Value);
            }

            var lastMove = "";
            var lastDuration = 0;
            foreach (var item in book)
            {
                Console.WriteLine($"{item.Key}");
                lastMove = item.Key;
                lastDuration = item.Value;
                var line = Console.ReadLine();
                if (line == "Yes")
                {
                    break;
                }
            }
            Console.WriteLine($"We're watching {lastMove} - {ConvertSeconds(lastDuration)}");
            Console.WriteLine($"Total Playlist Duration: {ConvertSeconds(moviesDurationSec)}");
        }

        static string ConvertSeconds(int secs)
        {
            int hours = secs / 3600;
            int mins = (secs % 3600) / 60;
            secs = secs % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, secs);
        }
    }
}
