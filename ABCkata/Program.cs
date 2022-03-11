using System;
using System.Collections.Generic;
namespace ABCKata;

public class Program
{
    public static void Main(string[] args)
    {
        var blockBuilder = new BlockBuilder();
        var WordChecker = new WordChecker("COMMON");
        WordChecker.BlocksToCheck = blockBuilder.BlocksToCheck;
        WordChecker.ExecuteAndPrint();
    }
}

// ask user if htey want to use their own sample or given sample
// have a block class, constructor with 2 arguments, first letter value and second letter value
// 3 properties, 1st value, 2nd value and isUsed
// Store blocks in a list of block objects
// Iterate through list and determine which blocks are used