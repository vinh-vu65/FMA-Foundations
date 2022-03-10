using System;
namespace Foundation;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        InputHandler handler = new InputHandler();
        Console.WriteLine("Welcome to Vinh's foundational katas");
        MenuOption userSelection = MenuOption.Continue;
        while (userSelection != MenuOption.Quit)
        {
            menu.PrintOptions();
            userSelection = menu.ReadMenuOption();
            switch (userSelection)
            {
                case MenuOption.SumFinder:
                    var sumFinder = new SumFinder();
                    sumFinder.UserChoice = handler.HandleInput();
                    sumFinder.Execute();
                    break;

                case MenuOption.ThreeFiveSum:
                    var threeFiveSum = new ThreeFiveSum();
                    threeFiveSum.UserChoice = handler.HandleInput();
                    threeFiveSum.Execute();
                    break;

                case MenuOption.SumOrProduct:
                    var sumOrProduct = new SumOrProduct();
                    sumOrProduct.UserChoice = handler.HandleInput();
                    sumOrProduct.Execute();
                    break;

                case MenuOption.MultiplicationTable:
                    var multiplicationTable = new MultiplicationTable();
                    multiplicationTable.UserChoice = handler.HandleInput();
                    multiplicationTable.Execute();
                    break;

                case MenuOption.GuessingGame:
                    var guessingGame = new GuessingGame();
                    guessingGame.UserChoice = handler.HandleInput();
                    guessingGame.Execute();
                    break;

                case MenuOption.FizzBuzz:
                    var fizzBuzz = new FizzBuzz();
                    fizzBuzz.UserChoice = handler.HandleInput();
                    fizzBuzz.Execute();
                    break;

                case MenuOption.Quit:
                    Console.WriteLine("You have chosen to quit");
                    userSelection = MenuOption.Quit;
                    return;
            }
            userSelection = menu.PrintFinishMessage();
        }
    }
}

//Refactor code so methods are not in constructor
//Add fields and properties
//inheritance / interface