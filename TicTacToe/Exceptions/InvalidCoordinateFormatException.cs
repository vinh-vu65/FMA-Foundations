namespace TicTacToe.Exceptions;

public class InvalidCoordinateFormatException : Exception
{
    public InvalidCoordinateFormatException() : base("Invalid format, enter co-ordinates in x,y format (ie. 2,1): ") {}
}