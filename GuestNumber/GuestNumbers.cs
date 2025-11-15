using System;
using System.Collections.Generic;
using System.Text;

namespace GuestNumber
{
    internal class GuestNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string secret = random.Next(100, 1000).ToString(); // 3-digit number

            Console.WriteLine("Guess the 3-digit number (5 tries).");

            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Try {i}: ");
                string guess = Console.ReadLine();

                if (guess.Length != 3)
                {
                    Console.WriteLine("Please enter exactly 3 digits.");
                    i--;
                    continue;
                }

                string hint = "";

                for (int j = 0; j < 3; j++)
                {
                    if (guess[j] == secret[j])
                    {
                        hint += "+"; // correct digit + correct position
                    }
                    else if (secret.Contains(guess[j]))
                    {
                        hint += "?"; // correct digit but wrong position
                    }
                    else
                    {
                        hint += "-"; // wrong digit
                    }
                }

                if (guess == secret)
                {
                    Console.WriteLine("🎉 You win!");
                    return;
                }

                Console.WriteLine($"Hint: {hint}");
            }

            Console.WriteLine($"\nYou lost! The number was: {secret}");
        }
    }
}
