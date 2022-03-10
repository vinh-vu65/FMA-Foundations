using System;
namespace Foundation;

public class ThreeFiveSum : IUserInputProgram
{
    public int UserChoice {get; set;}
    public void Execute()
    {
        PrintInitialMessage();
        FindThreeFiveSum(UserChoice);
    }
    public void PrintInitialMessage()
    {
        Console.WriteLine("\n You have chosen to run Three Five Sum");
        Console.WriteLine("Please enter a positive number (n) and the program will calculate the sum of all numbers from 1 to n that are divisible by 3 or 5.");
    }
    public void FindThreeFiveSum(int num)
    {
        int sum = 0;
        for (int i = 0; i <= num; i++)
        {
            if (i % 3 == 0 && i % 5 != 0)
                sum += i;
            if (i % 3 != 0 && i % 5 == 0)
                sum += i;
            if (i % 3 == 0 && i % 5 == 0)
                sum += i;
        }
        Console.WriteLine($"\n The sum of all numbers divisible by 3 or 5, from 1 to {num} is: {sum}");
    }
}