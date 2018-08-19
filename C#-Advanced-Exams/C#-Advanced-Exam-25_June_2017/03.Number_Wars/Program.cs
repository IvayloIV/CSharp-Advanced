using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var secondPlayerCards = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var queueCardsFirst = new Queue<string>(firstPlayerCards);
            var queueCardsSecond = new Queue<string>(secondPlayerCards);

            var turn = 0;
            while (true)
            {
                if (turn >= 1000000 || queueCardsFirst.Count == 0 || queueCardsSecond.Count == 0)
                {
                    break;
                }
                turn++;
                var firstPlayerCard = queueCardsFirst.Dequeue();
                var secondPlayerCard = queueCardsSecond.Dequeue();

                var firstCartNum = GetNumberOfCard(firstPlayerCard);
                var secondCartNum = GetNumberOfCard(secondPlayerCard);
                if (firstCartNum > secondCartNum)
                {
                    queueCardsFirst.Enqueue(firstPlayerCard);
                    queueCardsFirst.Enqueue(secondPlayerCard);
                }
                else if (firstCartNum < secondCartNum)
                {
                    queueCardsSecond.Enqueue(secondPlayerCard);
                    queueCardsSecond.Enqueue(firstPlayerCard);
                }
                else
                {
                    var counter = 1;
                    var firstSum = 0;
                    var secondSum = 0;
                    var isEnd = false;
                    var cards = new List<string>
                    {
                        firstPlayerCard,
                        secondPlayerCard
                    };
                    while (true)
                    {
                        if (queueCardsFirst.Count == 0 || queueCardsSecond.Count == 0)
                        {
                            isEnd = true;
                            break;
                        }
                        var firstPlayerCardInnter = queueCardsFirst.Dequeue();
                        var secondPlayerCardInnter = queueCardsSecond.Dequeue();

                        cards.Add(firstPlayerCardInnter);
                        cards.Add(secondPlayerCardInnter);

                        firstSum += GetletterSum(firstPlayerCardInnter);
                        secondSum += GetletterSum(secondPlayerCardInnter);
                        if (counter++ % 3 == 0 && firstSum != secondSum)
                        {
                            break;
                        }
                    }
                    if (firstSum > secondSum)
                    {
                        cards = AddCards(cards, queueCardsFirst);
                    }
                    else if (firstSum < secondSum)
                    {
                        cards = AddCards(cards, queueCardsSecond);
                    }
                    if (isEnd)
                    {
                        break;
                    }
                }
            }
            PrintResult(turn, queueCardsFirst, queueCardsSecond);
        }

        private static void PrintResult(int turn, Queue<string> firstPlayerCards, Queue<string> secondPlayerCards)
        {
            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {turn} turns");
            }
            else if (firstPlayerCards.Count < secondPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins after {turn} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turn} turns");
            }
        }

        private static int GetletterSum(string firstPlayerCard)
        {
            return firstPlayerCard[firstPlayerCard.Length - 1];
        }

        private static List<string> AddCards(List<string> cards, Queue<string> queueCards)
        {
            foreach (var card in cards.OrderByDescending(a => GetNumberOfCard(a)).ThenByDescending(a => GetletterSum(a)))
            {
                queueCards.Enqueue(card);
            }
            return new List<string>();
        }

        private static int GetNumberOfCard(string firstPlayerCard)
        {
            return int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
        }
    }
}