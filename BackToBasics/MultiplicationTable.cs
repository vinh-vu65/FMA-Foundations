using System;
namespace Foundation;

public class MultiplicationTable
{
    public int UserChoice;
    public const int MultiplicationTableUpperLimit = 12;
    public void Execute()
    {
        PrintInitialMessage();
        for (int i = 1; i <= UserChoice; i += 6)
        {
            if (i + 5 > UserChoice)
            {
                PrintMultiplicationTables(i, UserChoice);
            }
            else
            {
                PrintMultiplicationTables(i, i + 5);
            }
        }
    }
    public void PrintInitialMessage()
    {
        Console.WriteLine("You have chosen to run Multiplication Table");
        Console.WriteLine("Please choose a number, the program will then display the multiplication tables from 1 to that number.");
    }
    public void PrintMultiplicationTables(int columnStart, int columnEnd)
    {
        for (int i = 1; i <= MultiplicationTableUpperLimit; i++)
        {
            for (int j = columnStart; j <= columnEnd; j++)
            {
                string equation = $"{j} x {i} = {i * j}";
                Console.Write(equation + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}