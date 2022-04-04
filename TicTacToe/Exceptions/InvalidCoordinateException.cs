namespace TicTacToe.Exceptions;

public class InvalidCoordinateException : Exception
{
    public InvalidCoordinateException() : base("Invalid input, enter co-ordinates in x,y format (ie. 2,1): ") {}
}