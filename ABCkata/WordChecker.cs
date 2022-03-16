using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
namespace ABCKata;

public class WordChecker
{
    public BlockBuilder blockBuilder;
    public List<Block> BlocksToCheck;
    public List<Block> BlockContainsLetter;
    public string InputWord {get; set;}

    public WordChecker()
    {
        blockBuilder = new BlockBuilder();
        this.BlocksToCheck = blockBuilder.BlocksToCheck;
    }
    public static bool IsValid(string str)
    {
        Regex reg = new Regex("^[a-zA-Z]+$");
        return reg.IsMatch(str);
    }
    public void ExecuteAndPrint()
    {
        InputWord = GetWordToSpell();
        if (InputWord.ToLower() == "q")
        {
            return;
        }
        var result = TrySpell(InputWord);
        Console.WriteLine($"Can we spell {InputWord.ToUpper()} with the given blocks: {result}");
    }
    public string GetWordToSpell()
    {
        string s;
        do
        {
            Console.Write("Please enter word to spell (or enter the letter q to quit): ");
            s = Console.ReadLine();
        }
        while (String.IsNullOrWhiteSpace(s) || !IsValid(s));
        return s.ToUpper();
    }
    public void ResetBlocks()
    {
        foreach (Block block in BlocksToCheck)
        {
            block.IsUsed = false;
        }
    }
    public bool TrySpell(string word)
    {
        ResetBlocks();
        return CanMake(word);
    }
    public bool CanMake(string word)
    {
        foreach (char letter in word)
        {
            bool found = false;
            foreach (Block block in BlocksToCheck)
            {
                if ((!block.IsUsed) && (block.FirstValue == letter || block.SecondValue == letter))
                {
                    block.IsUsed = true;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return false;
            }
        }
        return true;
    }
}