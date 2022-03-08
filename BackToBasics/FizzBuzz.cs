using System;

namespace Foundation
{
    public class FizzBuzz
    {
        public FizzBuzz()
        {
            InitialPrintMessage();
            int input = HandleInput();
            PrintFizzBuzz(input);
        }
        public void InitialPrintMessage()
        {
            Console.WriteLine("\n You have chosen to run FizzBuzz!");
            Console.WriteLine("Please choose a positive number (n) and the console will print all of the numbers from 1 to n");
            Console.WriteLine("If a number is divisible by 3, the console will print \"Fizz\"");
            Console.WriteLine("If a number is divisible by 5, the console will print \"Buzz\"");
            Console.WriteLine("If a number is divisible by both 3 and 5, the console will print \"FizzBuzz\"");
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
        public void PrintFizzBuzz(int num)
        {
            Console.WriteLine($"\n The console will now print FizzBuzz for numbers 1 to {num}");
            for (int i = 1 ; i <= num ; i++ )
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else   
                    Console.WriteLine(i);
            }
        }
    }
}