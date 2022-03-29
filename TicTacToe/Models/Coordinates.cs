namespace TicTacToe.Models;

public class Coordinates
{
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public string Value { get; set; }

    public Coordinates(int X, int Y)
    {
        CoordX = X;
        CoordY = Y;
        Value = ".";
    }

    public override string ToString()
    {
        return $"{CoordX},{CoordY}";
    }
}