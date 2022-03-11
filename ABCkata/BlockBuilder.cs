using System;
using System.Collections.Generic;
namespace ABCKata;

public class BlockBuilder
{
    public List<Block> BlocksToCheck;
    public BlockBuilder()
    {
        BlocksToCheck = LoadSampleBlocks();
    }
    public List<Block> LoadSampleBlocks()
    {
        List<Block> sampleBlocks = new List<Block>
        {
            new Block('B', 'O'),
            new Block('X', 'K'),
            new Block('D', 'Q'),
            new Block('C', 'P'),
            new Block('N', 'A'),
            new Block('G', 'T'),
            new Block('R', 'E'),
            new Block('T', 'G'),
            new Block('Q', 'D'),
            new Block('F', 'S'),
            new Block('J', 'W'),
            new Block('H', 'U'),
            new Block('V', 'I'),
            new Block('A', 'N'),
            new Block('O', 'B'),
            new Block('E', 'R'),
            new Block('F', 'S'),
            new Block('L', 'Y'),
            new Block('P', 'C'),
            new Block('Z', 'M'),
        };
        return sampleBlocks;
    }

    //TODO: Write method to load blocks as input from user
    //public List<Block> UserInputBlocks()
    //{
    //    List<Block> userBlocks = new List<Block>();
    //    Console.WriteLine("Please enter first block letter");
    //    return userBlocks;
    //}
}