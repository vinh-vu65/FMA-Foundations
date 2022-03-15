using System;
using System.Collections.Generic;
namespace ABCKata;

public class WordChecker
{
    public List<Block> BlocksToCheck;
    public List<Block> BlockContainsLetter;
    public string InputWord;

    public void ExecuteAndPrint()
    {
        Console.Write("Please enter word to spell: ");
        InputWord = Console.ReadLine();
        GatherBlocks(InputWord);
        var result = TrySpell(InputWord);
        Console.WriteLine($"Can we spell {InputWord} with the given blocks: {result}");
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

    public bool TrySpell(string word)
    {
        if (BlockContainsLetter.Count < word.Length)
            return false;
        List<char> wordToList = word.ToList();
        return CompareBlockCharToCharList(wordToList);
    }
    
    // Iterate over new sublist of Blocks and remove letters from the given word as blocks are found
    public bool CompareBlockCharToCharList(List<char> wordList)
    {
        var remainingLetters = new List<char>(wordList);
        foreach (char letter in wordList)
        {
            foreach (Block block in BlockContainsLetter)
            {
                if ((!block.IsUsed) && block.FirstValue == Char.ToUpper(letter))
                {
                    block.IsUsed = true;
                    remainingLetters.Remove(letter);
                    break;
                }
                if ((!block.IsUsed) && block.SecondValue == Char.ToUpper(letter))
                {
                    block.IsUsed = true;
                    remainingLetters.Remove(letter);
                    break;
                }
            }
        }
        if (remainingLetters.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}