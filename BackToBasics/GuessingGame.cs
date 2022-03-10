using System;

namespace Foundation;

public class GuessingGame
{
    public int UserChoice;
    private int _numberToGuess;
    private int _userGuess;
    private int _guessCount;
    public void Execute()
    {
        PrintInitialMessage();
        RunGuessingGame(UserChoice);
    }
    public void PrintInitialMessage()
    {
        Console.WriteLine("You have chosen to run Guessing Game");
        Console.WriteLine("Please choose a number (n). The program will choose a random number between 1 and n and you have to guess what the number is");
        Console.WriteLine("Good luck!");
    }
    public void RunGuessingGame(int maxNumber)
    {
        int minNumber = 1;
        bool parseInput;
        Random rnd = new Random();
        _numberToGuess = rnd.Next(1, maxNumber + 1);
        _guessCount = 0;

        do
        {
            Console.WriteLine($"Guess a number between {minNumber} and {maxNumber}");
            parseInput = Int32.TryParse(Console.ReadLine(), out _userGuess);
            if (_userGuess > _numberToGuess && _userGuess < maxNumber)
            {
                Console.WriteLine("That guess was too high, try again.");
                maxNumber = _userGuess;
                _guessCount++;
            }
            if (_userGuess < _numberToGuess && _userGuess > minNumber)
            {
                Console.WriteLine("That guess was too low, try again.");
                minNumber = _userGuess;
                _guessCount++;
            }
        } while (!parseInput || _userGuess != _numberToGuess);
        _guessCount++;
        Console.WriteLine($"Correct! The number was {_numberToGuess}");
        Console.WriteLine($"You guessed it in {_guessCount} tries!");
    }
}
