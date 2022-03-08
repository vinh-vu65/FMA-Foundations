using System;

namespace Foundation 
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Vinh's Foundational katas");
            MenuOption userSelection;
            do
            {
                userSelection = ReadMenuOption();
                switch (userSelection)
                {
                    case MenuOption.SumFinder:
                    var sumFinder = new SumFinder();
                    break;
                }
            } while (userSelection != MenuOption.Quit); 
        }

        public static MenuOption ReadMenuOption()
        {
            int option;
            Console.WriteLine("\n Please choose a program to run!");
            Console.WriteLine("1. Sum Finder");
            Console.WriteLine("2. Three Five Sum");
            Console.WriteLine("3. Sum Or Product");
            Console.WriteLine("4. Multiplication Table");
            Console.WriteLine("5. Guessing Game");
            Console.WriteLine("6. Leap Year");
            
            do 
            {
                Console.Write("Enter a number from 1 - 6 to make your choice or enter 0 to quit:");
                Int32.TryParse(Console.ReadLine(), out option);
            } while (option < 0 || option > 6);
            
            return (MenuOption)(option);
        }
    }
    public enum MenuOption 
    {
        Quit,
        SumFinder,
        ThreeFiveSum,
        SumOrProduct,
        MultiplicationTable,
        GuessingGame,
        LeapYear
    }
}





/*
TASKS:
Write a program that asks the user for a number n and prints the sum of the numbers 1 to n
Write a program that asks the user for a number n and prints the sum of the numbers 1 to n if the number is a multiple of three or five, e.g. 3, 5, 6, 9, 10, 12, 15 for n=17
Write a program that asks the user for a number n and gives them the possibility to choose between computing the sum and computing the product of 1,…,n.
Write a program that prints a multiplication table for numbers up to 12.
Write a guessing game where the user has to guess a secret number. After every guess the program tells the user whether their number was too large or too small. At the end the number of tries needed should be printed. It counts only as one try if they input the same number multiple times consecutively.
Write a program that prints the next 20 leap years.
*/