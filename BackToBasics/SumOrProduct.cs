using System;
namespace Foundation;

public class SumOrProduct : IUserInputProgram
{
    public int UserChoice {get; set;}
    private bool _userChoseSum;
    public void Execute()
    {
        PrintInitialMessage();
        Console.WriteLine($"You have chosen {UserChoice}.");
        ChooseSumOrProduct();
        if (_userChoseSum)
            FindSum(UserChoice);
        else
            FindProduct(UserChoice);
    }
    public void PrintInitialMessage()
    {
        Console.WriteLine("\n You have chosen to run Sum Or Product");
        Console.WriteLine("Please enter a positive number (n)");
        Console.WriteLine("The program will then ask if you want to sum or product");
        Console.WriteLine("Sum: The program will find the sum of all numbers from 1 to n.");
        Console.WriteLine("Product: The program will find the product of all numbers from 1 to n.");
    }
    public void ChooseSumOrProduct()
    {
        int option;
        Console.WriteLine("Would you like to find the sum or the product?");
        do
        {
            Console.WriteLine("Enter 1 for Sum, Enter 2 for product");
            Int32.TryParse(Console.ReadLine(), out option);
        } while (option < 1 || option > 2);
        if (option == 1)
            _userChoseSum = true;
        else if (option == 2)
            _userChoseSum = false;
    }
    public void FindSum(int num)
    {
        double sum = 0;
        for (int i = 0; i <= num; i++)
        {
            sum += i;
        }
        Console.WriteLine($"\n The sum of all numbers from 1 to {num} is: {sum}");
    }
    public void FindProduct(int num)
    {
        double product = 1;
        for (int i = 1; i <= num; i++)
        {
            product *= i;
        }
        Console.WriteLine($"\n The product of all numbers from 1 to {num} is: {product}");
    }
}