using System;
using System.Collections.Generic;
namespace ABCKata;

public class Program
{
    public static void Main(string[] args)
    {
        var blockBuilder = new BlockBuilder();
        var wordChecker = new WordChecker();
        wordChecker.BlocksToCheck = blockBuilder.BlocksToCheck;
        wordChecker.ExecuteAndPrint();
    }
}
