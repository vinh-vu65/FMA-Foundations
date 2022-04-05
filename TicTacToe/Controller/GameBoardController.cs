using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameBoardController
{
    public GameBoard GameBoard { get; }

    public GameBoardController(GameBoard gameBoard)
    {
        GameBoard = gameBoard;
    }

    public bool IsMoveValid(string coordinates)
    {
        foreach (var coord in GameBoard.BoardCoordinates)
        {
            if (coord.ToString() == coordinates && coord.IsUsed())
            {
                return false;
            }
        }

        return true;
    }
    
    public void UpdateBoard(string coordinates, string boardMarker)
    {
        foreach (var coord in GameBoard.BoardCoordinates)
        {
            if (coord.ToString() == coordinates)
            {
                coord.Value = boardMarker;
                GameBoard.MovesAccepted++;
            }
        }
    }
}