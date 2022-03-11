using System;
namespace ABCKata;

public class WordChecker
{
    public List<Block> BlocksToCheck;
    public List<Block> BlockContainsLetter;
    public string InputWord;
    public WordChecker(string InputWord)
    {
        this.InputWord = InputWord;
    }
    
    // Iterate over char array of input word.
    // If any of the blocks contain the same letter required in input word, add to new list of Blocks. 
    public void GatherBlocks(string word)
    {
        char[] charArray = word.ToCharArray();
        for (int i = 0 ; i < charArray.Length ; i++)
        {
            foreach (Block block in BlocksToCheck)
            {
                if ((block.IsUsed == false) && (block.FirstValue == Char.ToUpper(charArray[i]) || block.SecondValue == Char.ToUpper(charArray[i])))
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
        foreach (char letter in wordToList)
        {
            foreach (Block block in BlockContainsLetter)
            {
                if (block.FirstValue == Char.ToUpper(letter))
                {
                    block.IsUsed = true;
                    wordToList.Remove(letter);
                }
            }
        }
        foreach (char letter in wordToList)
        {
            foreach (Block block in BlockContainsLetter)
            {
                if ((!block.IsUsed) && block.SecondValue == Char.ToUpper(letter))
                {
                    block.IsUsed = true;
                    wordToList.Remove(letter);
                }
            }
        }
        if (wordToList == null)
        {
            return true;
        } else return false;
    }
    // TODO: Refactor above method to remove duplicate code


    //public void CompareCharacterFromBlock(char c, List<char> word)
    //{
    //    foreach (char letter in word)
    //    {
    //        if (letter == c)
    //            return true;
    //        else 
    //            return false;
    //    }
    //}
}