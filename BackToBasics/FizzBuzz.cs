using System;

namespace Foundation
{
    public class FizzBuzz
    {
        public int UserChoice;
        public void Execute()
        {
            InitialPrintMessage();
            PrintFizzBuzz(UserChoice);
        }
        public void InitialPrintMessage()
        {
            Console.WriteLine("\n You have chosen to run FizzBuzz!");
            Console.WriteLine("Please choose a positive number (n) and the console will print all of the numbers from 1 to n");
            Console.WriteLine("If a number is divisible by 3, the console will print \"Fizz\"");
            Console.WriteLine("If a number is divisible by 5, the console will print \"Buzz\"");
            Console.WriteLine("If a number is divisible by both 3 and 5, the console will print \"FizzBuzz\"");
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