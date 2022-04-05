namespace TicTacToe.Exceptions;

public class OutOfBoundsException : Exception
{
    public OutOfBoundsException(int boardSize) : base($"Coordinates out of bounds, enter coordinates between " +
                                                      $"(1,1) and ({boardSize},{boardSize})") { }
}