using System;
namespace Foundation;

public class SumFinder
{
    public int UserChoice;
    public void Execute()
    {
        InitialPrintMessage();
        FindSum(UserChoice);
    }
    public void InitialPrintMessage()
    {
        Console.WriteLine("\n You have chosen to run the Sum Finder");
        Console.WriteLine("Please enter a positive number (n) and the program will calculate the sum of all numbers from 1 to n.");
    }
    public void FindSum(int num)
    {
        int sum = 0;
        for (int i = 0; i <= num; i++)
        {
            sum += i;
        }
        Console.WriteLine($"\n The sum of all numbers from 1 to {num} is: {sum}");
    }
}