using System;

namespace Foundation
{
    public class GuessingGame
    {
        public GuessingGame()
        {
            
        }
        public void Execute()
        {
            PrintInitialMessage();
            int input = HandleInput();
            RunGuessingGame(input);
        }
        public void PrintInitialMessage()
        {
            Console.WriteLine("You have chosen to run Guessing Game");
            Console.WriteLine("Please choose a number (n). The program will choose a random number between 1 and n and you have to guess what the number is");
            Console.WriteLine("Good luck!");
        }
        public int HandleInput()
        {
            int userInput;
            do 
            {
                Console.WriteLine("Please enter a number greater than zero: ");
                Int32.TryParse(Console.ReadLine(), out userInput);
            } while (userInput <= 0);
            return userInput;
        }
        public void RunGuessingGame(int maxNumber)
        {
            Random rnd = new Random();
            int numberToGuess = rnd.Next(1, maxNumber + 1);
            int userGuess;
            int minNumber = 1;
            int guessCount = 0;
            bool parseInput;
            do
            {
                Console.WriteLine($"Guess a number between {minNumber} and {maxNumber}");
                parseInput = Int32.TryParse(Console.ReadLine(), out userGuess);
                if (userGuess > numberToGuess && userGuess < maxNumber)
                {
                    Console.WriteLine("That guess was too high, try again.");
                    maxNumber = userGuess;
                    guessCount++;
                }
                if (userGuess < numberToGuess && userGuess > minNumber)
                {
                    Console.WriteLine("That guess was too low, try again.");
                    minNumber = userGuess;
                    guessCount++;
                }
            } while (!parseInput || userGuess != numberToGuess);
            guessCount++;
            Console.WriteLine($"Correct! The number was {numberToGuess}");
            Console.WriteLine($"You guessed it in {guessCount} tries!");
        }
    }
}