using System;
using System.Collections.Generic;
namespace ABCKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the ABC Kata Word Checker! \n");
        var wordChecker = new WordChecker();
        do
        {
            wordChecker.ExecuteAndPrint();
        } while (wordChecker.InputWord.ToLower() != "q");
    }
}
