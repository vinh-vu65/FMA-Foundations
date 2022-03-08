using System;

namespace Foundation 
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            Console.WriteLine("Welcome to Vinh's foundational katas");
            MenuOption userSelection;
            do
            {
                menu.PrintOptions();
                userSelection = menu.ReadMenuOption();
                switch (userSelection)
                {
                    case MenuOption.SumFinder:
                    var sumFinder = new SumFinder();
                    userSelection = menu.PrintFinishMessage();
                    break;

                    case MenuOption.ThreeFiveSum:
                    var threeFiveSum = new ThreeFiveSum();
                    userSelection = menu.PrintFinishMessage();
                    break;

                    case MenuOption.SumOrProduct:
                    var sumOrProduct = new SumOrProduct();
                    userSelection = menu.PrintFinishMessage();
                    break;
                    
                    case MenuOption.MultiplicationTable:
                    userSelection = menu.PrintFinishMessage();
                    break;

                    case MenuOption.GuessingGame:
                    userSelection = menu.PrintFinishMessage();
                    break;

                    case MenuOption.LeapYear:
                    userSelection = menu.PrintFinishMessage();
                    break;

                    case MenuOption.FizzBuzz:
                    var fizzBuzz = new FizzBuzz();
                    userSelection = menu.PrintFinishMessage();
                    break;
                }
            } while (userSelection != MenuOption.Quit); 
        }

        
    }
}

/*
TASKS:
Write a program that prints a multiplication table for numbers up to 12.
Write a guessing game where the user has to guess a secret number. After every guess the program tells the user whether their number was too large or too small. At the end the number of tries needed should be printed. It counts only as one try if they input the same number multiple times consecutively.
Write a program that prints the next 20 leap years.
*/