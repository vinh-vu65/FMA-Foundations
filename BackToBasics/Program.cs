using System;
namespace Foundation;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
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
                    sumFinder.Execute();
                    break;

                case MenuOption.ThreeFiveSum:
                    var threeFiveSum = new ThreeFiveSum();
                    break;

                case MenuOption.SumOrProduct:
                    var sumOrProduct = new SumOrProduct();
                    break;

                case MenuOption.MultiplicationTable:
                    var multiplicationTable = new MultiplicationTable();
                    break;

                case MenuOption.GuessingGame:
                    var guessingGame = new GuessingGame();
                    break;

                case MenuOption.FizzBuzz:
                    var fizzBuzz = new FizzBuzz();
                    break;

                case MenuOption.Quit:
                    Console.WriteLine("You have chosen to quit");
                    userSelection = MenuOption.Quit;
                    return;
            }
            //userSelection = menu.PrintFinishMessage();
        }
    }
}
