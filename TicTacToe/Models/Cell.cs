namespace TicTacToe.Models;

public class Cell
{
    private readonly int _x;
    private readonly int _y;
    public string Value { get; set; }
    
    public Cell(int x, int y)
    {
        _x = x;
        _y = y;
        Value = ".";
    }

    public bool IsUsed()
    {
        return (Value != ".");
    }

    public override string ToString()
    {
        return $"{_x},{_y}";
    }
}