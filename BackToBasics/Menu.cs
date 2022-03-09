using System;

namespace Foundation
{
    public enum MenuOption 
    {
        Quit,
        SumFinder,
        ThreeFiveSum,
        SumOrProduct,
        MultiplicationTable,
        GuessingGame,
        FizzBuzz,
        Continue
    }
    public class Menu
    {
        public void PrintOptions()
        {
            Console.WriteLine("\n Please choose a program to run!");
            Console.WriteLine("1. Sum Finder");
            Console.WriteLine("2. Three Five Sum");
            Console.WriteLine("3. Sum Or Product");
            Console.WriteLine("4. Multiplication Table");
            Console.WriteLine("5. Guessing Game");
            Console.WriteLine("6. FizzBuzz");
        }
        public MenuOption ReadMenuOption()
        {
            int option;
            bool tryParse;
            do 
            {
                Console.Write("Enter a number from 1 - 6 to make your choice or enter 0 to quit:");
                tryParse = Int32.TryParse(Console.ReadLine(), out option);
            } while ((option < 0 || option > 6) || (!tryParse));
            return (MenuOption)(option);
        }
        public MenuOption PrintFinishMessage()
        {
            Console.WriteLine("\n Would you like to try another program?");
            Console.Write("Press Q to quit, or any other key to continue: ");
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                return MenuOption.Quit;
            } else return MenuOption.Continue;
        }
    }
}