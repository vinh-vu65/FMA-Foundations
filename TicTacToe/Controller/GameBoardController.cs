using TicTacToe.Models;

namespace TicTacToe.Controller;

public class GameBoardController
{
    private readonly GameBoard _gameBoard;

    public GameBoardController(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public bool IsMoveValid(string coordinates)
    {
        foreach (var coord in _gameBoard.BoardCoordinates)
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
        foreach (var coord in _gameBoard.BoardCoordinates)
        {
            if (coord.ToString() == coordinates)
            {
                coord.Value = boardMarker;
                _gameBoard.MovesAccepted++;
            }
        }
    }
}