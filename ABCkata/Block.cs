using System;
using System.Collections.Generic;
namespace ABCKata;

public class Block
{
    public char FirstValue {get; set;}
    public char SecondValue {get; set;}
    public bool IsUsed {get; set;}
    
    public Block(char firstValue, char secondValue)
    {
        FirstValue = firstValue;
        SecondValue = secondValue;
        IsUsed = false;
    }
}