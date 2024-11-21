using System;
using System.Collections.Generic;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 101); // Random number between 1 and 100
            List<Guess> guesses = new List<Guess>();
            int userGuess = -1;

            Console.WriteLine("Welcome Guessing Game!");
            Console.WriteLine("take a wild guess but keep it between between 1 and 100.");

            do
            {
                Console.Write("so what you think it is : ");
                string? input = Console.ReadLine();
                input = input ?? string.Empty;
                
                if (!int.TryParse(input, out userGuess) || userGuess < 1 || userGuess > 100)
                {
                    Console.WriteLine("oy ,oy,oy , keep it under 100 ! ALRIGHT.");
                    continue; // Prompt the user again
                }

                
                int previousIndex = guesses.FindIndex(g => g.UserGuess == userGuess);
                if (previousIndex >= 0)
                {
                    int turnsAgo = guesses.Count - previousIndex;
                    Console.WriteLine($"You guessed this number {turnsAgo} turn(s) ago!");
                    continue; 
                }

                
                guesses.Add(new Guess(userGuess));

               
                if (userGuess > randomNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else if (userGuess < randomNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine($"You won! The answer was {randomNumber}.");
                    Console.WriteLine($"It took you {guesses.Count} guess(es) to win.");
                    break; // Exit the loop when the user wins
                }
            } while (true);
        }
    }

    // Guess class to store user guesses and their timestamps
    public class Guess
    {
        public int UserGuess { get; }
        public DateTime GuessTime { get; }

        public Guess(int userGuess)
        {
            UserGuess = userGuess;
            GuessTime = DateTime.Now;
        }
    }
}
