using System;

namespace Foundation
{
    public class SumFinder
    {
        public SumFinder()
        {
            InitialPrintMessage();
            int userInput = HandleInput();
            FindSum(userInput);
        }
        
        public void InitialPrintMessage()
        {
            Console.WriteLine("\n You have chosen to run the Sum Finder");
            Console.WriteLine("Please enter a positive number (n) and the program will calculate the sum of all numbers from 1 to n.");
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
        public void FindSum (int num)
        {
            int sum = 0;
            for (int i = 0 ; i <= num ; i++)
            {
                sum += i;
            }
            Console.WriteLine($"The sum of all numbers from 1 to {num} is: {sum}");
        }
        
    }
}