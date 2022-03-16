using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
namespace ABCKata;

public class WordChecker
{
    public BlockBuilder blockBuilder;
    public List<Block> BlocksToCheck;
    public List<Block> BlockContainsLetter;
    public string InputWord;

    public WordChecker()
    {
        blockBuilder = new BlockBuilder();
        this.BlocksToCheck = blockBuilder.BlocksToCheck;
    }
    public static bool RegexValid(string str)
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
        GatherBlocks(InputWord);
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
        while (String.IsNullOrWhiteSpace(s) || !RegexValid(s));
        return s;
    }

    // Create smaller sublist of Blocks which contain same letters as input word.
    public void GatherBlocks(string word)
    {
        word = word.ToUpper();
        BlockContainsLetter = new List<Block>();
        foreach (Block block in BlocksToCheck)
        {
            if (word.Contains(block.FirstValue) || word.Contains(block.SecondValue))
            {
                BlockContainsLetter.Add(block);
            }
        }
    }
    public void ResetBlocks()
    {
        foreach (Block block in BlockContainsLetter)
        {
            block.IsUsed = false;
        }
    }

    public bool TrySpell(string word)
    {
        if (BlockContainsLetter.Count < word.Length)
        {
            return false;
        }
        ResetBlocks();
        return CanMake(word);
    }

    // Iterate over new sublist of Blocks and remove letters from the given word as blocks are found
    public bool CanMake(string word)
    {
        foreach (char letter in word)
        {
            bool found = false;
            foreach (Block block in BlockContainsLetter)
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