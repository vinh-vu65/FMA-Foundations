using System;
namespace ABCKata;

public class Block
{
    public char FirstValue;
    public char SecondValue;
    public bool IsUsed;
    public Block(char FirstValue, char SecondValue)
    {
        this.FirstValue = FirstValue;
        this.SecondValue = SecondValue;
    }
    
}