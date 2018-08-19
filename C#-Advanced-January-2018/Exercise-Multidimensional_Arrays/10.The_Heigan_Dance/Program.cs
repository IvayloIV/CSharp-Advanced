using System;

namespace _10.The_Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {
            var damageToHeigan = double.Parse(Console.ReadLine());
            var playerHealth = 18500;
            double heiganHealth = 3000000;
            var playerRow = 7;
            var playerCow = 7;
            var lastDamage = 0;
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var attackName = input[0];
                var attackRow = int.Parse(input[1]);
                var attackCow = int.Parse(input[2]);
                var startRowDamage = Math.Max(0, attackRow - 1);
                var endRowDamage = Math.Min(14, attackRow + 1);
                var startCowDamage = Math.Max(0, attackCow - 1);
                var endCowDamage = Math.Min(14, attackCow + 1);
                heiganHealth -= damageToHeigan;
                if (lastDamage != 0)
                {
                    playerHealth -= lastDamage;
                    lastDamage = 0;
                    if (playerHealth <= 0)
                    {
                        PrintResult(playerHealth, heiganHealth, playerRow, playerCow, "Plague Cloud");
                        break;
                    }
                }
                if (heiganHealth <= 0)
                {
                    PrintResult(playerHealth, heiganHealth, playerRow, playerCow, attackName);
                    break;
                }
                if (playerRow >= startRowDamage && playerRow <= endRowDamage && playerCow >= startCowDamage && playerCow <= endCowDamage)
                {
                    if (playerRow - 1 < startRowDamage && playerRow - 1 >= 0)
                    {
                        playerRow -= 1;
                    }
                    else if (playerCow + 1 > endCowDamage && playerCow + 1 <= 14)
                    {
                        playerCow += 1;
                    }
                    else if (playerRow + 1 > endRowDamage && playerRow + 1 <= 14)
                    {
                        playerRow += 1;
                    }
                    else if (playerCow - 1 < startCowDamage && playerCow - 1 >= 0)
                    {
                        playerCow -= 1;
                    }
                    else
                    {
                        if (attackName == "Cloud")
                        {
                            playerHealth -= 3500;
                            lastDamage = 3500;
                        }
                        else if (attackName == "Eruption")
                        {
                            playerHealth -= 6000;
                        }
                        if (playerHealth <= 0)
                        {
                            PrintResult(playerHealth, heiganHealth, playerRow, playerCow, attackName);
                            break;
                        }
                    }
                }
            }
        }

        private static void PrintResult(int playerHealth, double heiganHealth, int row, int cow, string attackName)
        {
            if (heiganHealth <= 0)
            {
                Console.WriteLine($"Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHealth:f2}");
            }
            if (playerHealth <= 0)
            {
                Console.WriteLine($"Player: Killed by {attackName}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHealth}");
            }
            Console.WriteLine($"Final position: {row}, {cow}");
        }
    }
}