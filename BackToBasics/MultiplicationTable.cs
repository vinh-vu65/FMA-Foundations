using System.Linq.Expressions;
using System;

namespace Foundation
{
    public class MultiplicationTable
    {
        public const int MaxMultiplication = 12;
        public MultiplicationTable()
        {
            int userInput = HandleInput();
            for (int i = 1 ; i <= userInput ; i += 6)
            {
                if (i + 5 > userInput)
                {
                    PrintMultiplicationTables(i, userInput);
                }
                else
                {
                    PrintMultiplicationTables(i, i+5);
                }
            }
        }
        public void PrintInitialMessage()
        {
            Console.WriteLine("You have chosen to run Multiplication Table");
            Console.WriteLine("Please choose a number, the program will then display the multiplication tables from 1 to that number.");
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
        public void PrintMultiplicationTables(int columnStart, int columnEnd)
        {
            for ( int i = 1 ; i <= MaxMultiplication ; i++ )
            {
                for ( int j = columnStart ; j <= columnEnd ; j++ )
                {
                    string equation = $"{j} x {i} = {i * j}";
                    Console.Write(equation + "\t");
                    //Console.Write(new string(' ', 14- multiplicationEquation.Length));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}