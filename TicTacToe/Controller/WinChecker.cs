using TicTacToe.Models;

namespace TicTacToe.Controller;

public class WinChecker
{
    public string Winner { get; private set; }
    private readonly GameBoard _gameBoard;
    
    public WinChecker(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    public void PerformWinCheck()
    {
        CheckRowsForWinner();
        CheckColumnsForWinner();
        CheckDiagonalForWinner();
    }
    
    public void CheckRowsForWinner()
    {
        for (int i = 0; i < _gameBoard.BoardCoordinates.Count; i += _gameBoard.Size)
        {
            var markerToCheck = _gameBoard.BoardCoordinates[i].Value;
            var isWinningRow = true;
            for (int j = 1; j < _gameBoard.Size; j++)
            {
                if (_gameBoard.BoardCoordinates[i + j].Value != markerToCheck)
                {
                    isWinningRow = false;
                    break;
                }
            }

            if (isWinningRow)
            {
                Winner = markerToCheck;
                return;
            }
        }
    }

    public void CheckColumnsForWinner()
    {
        for (int i = 0; i < _gameBoard.Size; i++)
        {
            var firstValue = _gameBoard.BoardCoordinates[i].Value;
            var isWinningColumn = true;
            for (int j = _gameBoard.Size; j < _gameBoard.BoardCoordinates.Count; j += _gameBoard.Size)
            {
                if (_gameBoard.BoardCoordinates[i + j].Value != firstValue)
                {
                    isWinningColumn = false;
                    break;
                }
            }

            if (isWinningColumn)
            {
                Winner = firstValue;
                return;
            }
        }
    }

    public void CheckDiagonalForWinner()
    {
        /* Following index of the coordinates:
        *
        *  For a R to L diagonal win, follows pattern of multiples of GameBoard.Size - 1
        * 
        *  For L to R diagonal win, follows pattern of multiples of GameBoard.Size + 1 (starting from zero)
        */
        var topLeftCellMarker = _gameBoard.BoardCoordinates[0].Value;
        var topRightCellMarker = _gameBoard.BoardCoordinates[_gameBoard.Size - 1].Value;
        var isLeftToRightWinningDiagonal = true;
        var isRightToLeftWinningDiagonal = true;

        for (int i = 1; i < _gameBoard.Size; i++)
        {
            if (topRightCellMarker != _gameBoard.BoardCoordinates[(i + 1) * (_gameBoard.Size - 1)].Value)
            {
                isRightToLeftWinningDiagonal = false;
            }

            if (topLeftCellMarker != _gameBoard.BoardCoordinates[i * (_gameBoard.Size + 1)].Value)
            {
                isLeftToRightWinningDiagonal = false;
            }
        }

        if (isLeftToRightWinningDiagonal)
        {
            Winner = topLeftCellMarker;
        }

        if (isRightToLeftWinningDiagonal)
        {
            Winner = topRightCellMarker;
        }
    }
}