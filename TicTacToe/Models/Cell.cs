namespace TicTacToe.Models;

public class Cell
{
    public int X { get; }
    public int Y { get; }
    public string Value { get; set; }
    

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        Value = ".";
    }

    public bool IsUsed()
    {
        return (Value != ".");
    }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}