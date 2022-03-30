namespace TicTacToe;

public static class GameMessages
{
    public static string WelcomeMessage = "Welcome to Tic Tac Toe!";
    public static string InitialBoardMessage = "Here's the current board:";
    public static string MoveAcceptedMessage = "Move accepted, here's the current board:";
    public static string InvalidMoveMessage = "Oh no, a piece is already at this place! Try again...";
    public static string PlayerXWinMessage = "Player X has won the game!";
    public static string PlayerOWinMessage = "Player O has won the game!";
    public static string GameTieMessage = "The game has ended in a tie.";
    public const int NumberOfRows = 3;
    public const int NumberOfColumns = 3;
}