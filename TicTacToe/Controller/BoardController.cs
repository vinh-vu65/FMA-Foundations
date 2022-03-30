using System.Xml.XPath;
using TicTacToe.Models;

namespace TicTacToe.Controller;

public class BoardController
{
    // Verify Input
    // Update Board
    public GameBoard GameBoard { get; set; }
    public string UserInput { get; set; }

    public BoardController(GameBoard gameBoard)
    {
        GameBoard = gameBoard;
    }

    public bool IsMoveValid()
    {
        foreach (var coord in GameBoard.BoardCoordinates)
        {
            if (coord.ToString() == UserInput && coord.IsUsed())
            {
                return false;
            }
        }

        return true;
    }
    public void UpdateBoard(IPlayer player)
    {
        foreach (var coord in GameBoard.BoardCoordinates)
        {
            if (coord.ToString() == UserInput)
            {
                coord.Value = player.BoardMarker;
            }
        }
    }
}