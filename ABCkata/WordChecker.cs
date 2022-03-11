using System;
using System.Collections.Generic;
namespace ABCKata;

public class WordChecker
{
    public List<Block> BlocksToCheck;
    public List<Block> BlockContainsLetter;
    public string InputWord;
    public WordChecker(string InputWord)
    {
        this.InputWord = InputWord;
        BlockContainsLetter = new List<Block>();
    }

    public void ExecuteAndPrint()
    {
        GatherBlocks(InputWord);
        var result = TrySpell(InputWord);
        Console.WriteLine($"Can we spell {InputWord} with the given blocks: {result}");
    }
    // Iterate over char array of input word.
    // If any of the blocks contain the same letter required in input word, add to new list of Blocks. 
    public void GatherBlocks(string word)
    {
        char[] charArray = word.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            foreach (Block block in BlocksToCheck)
            {
                if ((!block.IsUsed) && (block.FirstValue == Char.ToUpper(charArray[i]) || block.SecondValue == Char.ToUpper(charArray[i])))
                {
                    BlockContainsLetter.Add(block);
                    block.IsUsed = true;
                }
            }
        }
    }

    // Iterate over new list of Blocks and try to spell word with this list of Blocks.
    public bool TrySpell(string word)
    {
        if (BlockContainsLetter.Count < word.Length)
            return false;
        List<char> wordToList = word.ToList();
        foreach (Block block in BlockContainsLetter)
        {
            block.IsUsed = false;
        }
        return CompareBlockCharToCharList(wordToList);
    }

    public bool CompareBlockCharToCharList(List<char> wordList)
    {
        var removedLetters = new List<char>(wordList);
        foreach (char letter in wordList)
        {
            foreach (Block block in BlockContainsLetter)
            {
                if ((!block.IsUsed) && block.FirstValue == Char.ToUpper(letter))
                {
                    block.IsUsed = true;
                    removedLetters.Remove(letter);
                }
                if ((!block.IsUsed) && block.SecondValue == Char.ToUpper(letter))
                {
                    block.IsUsed = true;
                    removedLetters.Remove(letter);
                }
            }
        }
        if (removedLetters.Count == 0)
        {
        return true;
        }
        else
            return false;
    }
}