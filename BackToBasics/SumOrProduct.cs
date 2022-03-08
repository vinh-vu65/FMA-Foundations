using System;

namespace Foundation
{
    public class SumOrProduct
    {
        public SumOrProduct()
        {
            int input;
            bool userChoseSum;
            InitialPrintMessage();
            input = HandleInput();
            Console.WriteLine($"You have chosen {input}.");
            userChoseSum = ChooseSumOrProduct();
            if (userChoseSum)
                FindSum(input);
            else
                FindProduct(input); 
        }
        public void InitialPrintMessage()
        {
            Console.WriteLine("\n You have chosen to run the Sum Or Product");
            Console.WriteLine("Please enter a positive number (n)");
            Console.WriteLine("The program will then ask if you want to sum or product");
            Console.WriteLine("Sum: The program will find the sum of all numbers from 1 to n.");
            Console.WriteLine("Product: The program will find the product of all numbers from 1 to n.");
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
        public bool ChooseSumOrProduct()
        {
            int option;
            Console.WriteLine("Would you like to find the sum or the product?");
            do 
            {
            Console.WriteLine("Enter 1 for Sum, Enter 2 for product");
            Int32.TryParse(Console.ReadLine(), out option);
            } while (option < 1 && option > 3);
            if (option == 1)
                return true;
            else 
                return false;
        }
        public void FindSum (int num)
        {
            int sum = 0;
            for (int i = 0 ; i <= num ; i++)
            {
                sum += i;
            }
            Console.WriteLine($"\n The sum of all numbers from 1 to {num} is: {sum}");
        }
        public void FindProduct (int num)
        {
            int product = 1;
            for (int i = 1 ; i <= num ; i++)
            {
                product *= i;
            }
            Console.WriteLine($"\n The product of all numbers from 1 to {num} is: {product}");
        }
    }
}