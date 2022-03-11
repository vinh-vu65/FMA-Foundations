using System;
namespace ABCKata;

public class WordChecker
{
    public List<Block> BlocksToCheck;
    public List<Block> BlockContainsLetter;
    public void GatherBlocks(string word)
    {
        char[] charArray = word.ToCharArray();
        for (int i = 0 ; i < charArray.Length ; i++)
        {
            foreach (Block block in BlocksToCheck)
            {
                if ((block.IsUsed == false) && (block.FirstValue == charArray[i] || block.SecondValue == charArray[i]))
                {
                    BlockContainsLetter.Add(block);
                    block.IsUsed = true;
                }
            }
        }
    }
    //TODO: Iterate through List of BlockContainsLetter to try and form given word
}