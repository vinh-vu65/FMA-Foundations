using System.Threading.Channels;
using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameEngine
{
    public bool IsGameOver { get; private set; }
    public string Winner { get; private set; }
    private readonly GameBoardController _boardController;
    private readonly GameBoard _gameBoard;
    private readonly HumanPlayer _playerOne;
    private readonly HumanPlayer _playerTwo;

    public GameEngine(GameBoardController boardController, GameBoard gameBoard, HumanPlayer playerOne, HumanPlayer playerTwo)
    {
        _boardController = boardController;
        _gameBoard = gameBoard;
        _playerOne = playerOne;
        _playerTwo = playerTwo;
    }

    public void RunGame()
    {
        PlayerTurn(_playerOne);
        if (_gameBoard.MovesAccepted >= 2 * _gameBoard.Size - 1) // Minimum number of moves before winner can be determined
        {
            DetermineWinner();
            if (IsGameOver)
            {
                return;
            }
        }
        if (IsGameTied()) 
        {
            IsGameOver = true;
            return;
        }
        PlayerTurn(_playerTwo);
        if (_gameBoard.MovesAccepted >= 2 * _gameBoard.Size - 1)
        {
            DetermineWinner();
        }
    }

    private void PlayerTurn(IPlayer player)
    {
        Printer.PlayerTurn(player);
        var turnCoord = player.ChooseCoordinates();
        while (!_boardController.IsMoveValid(turnCoord))
        {
            Printer.InvalidMove();
            turnCoord = player.ChooseCoordinates();
        }

        _boardController.UpdateBoard(turnCoord, player.BoardMarker);
        Printer.AcceptedMove();
        Printer.GameBoard(_gameBoard);
    }

    private bool IsGameTied()
    {
        return (_gameBoard.MovesAccepted == _gameBoard.BoardCoordinates.Count);
    }

    private void CheckRowsForWinner()
    {
        for (int i = 0; i < _gameBoard.BoardCoordinates.Count; i += _gameBoard.Size)
        {
            var firstValue = _gameBoard.BoardCoordinates[i].Value;
            var isWinningRow = true;
            for (int j = 1; j < _gameBoard.Size; j++)
            {
                if (_gameBoard.BoardCoordinates[i + j].Value != firstValue)
                {
                    isWinningRow = false;
                    break;
                }
            }

            if (isWinningRow)
            {
                Winner = firstValue;
                return;
            }
        }
    }

    private void CheckColumnsForWinner()
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

    private void CheckDiagonalForWinner()
    {
        // Following index of the coordinates:
        // For a R to L diagonal win, follows pattern of multiples of GameBoard.Size - 1
        
        // For L to R diagonal win, follows pattern of multiples of GameBoard.Size + 1 (starting from zero)
        
        var leftToRightDiagonal = _gameBoard.BoardCoordinates[0].Value;
        var rightToLeftDiagonal = _gameBoard.BoardCoordinates[_gameBoard.Size - 1].Value;
        var isLeftToRightWinningDiagonal = true;
        var isRightToLeftWinningDiagonal = true;

        for (int i = 1; i < _gameBoard.Size; i++)
        {
            if (rightToLeftDiagonal != _gameBoard.BoardCoordinates[(i + 1) * (_gameBoard.Size - 1)].Value)
            {
                isRightToLeftWinningDiagonal = false;
                break;
            }

            if (leftToRightDiagonal != _gameBoard.BoardCoordinates[i * (_gameBoard.Size + 1)].Value)
            {
                isLeftToRightWinningDiagonal = false;
                break;
            }
        }

        if (isLeftToRightWinningDiagonal)
        {
            Winner = leftToRightDiagonal;
        }

        if (isRightToLeftWinningDiagonal)
        {
            Winner = rightToLeftDiagonal;
        }
    }

    private void DetermineWinner()
    {
        CheckColumnsForWinner();
        CheckRowsForWinner();
        CheckDiagonalForWinner();
        if (Winner == _playerTwo.BoardMarker || Winner == _playerOne.BoardMarker)
        {
            IsGameOver = true;
        }
    }

    public void PrintOutcome(string winner)
    {
        if (winner == _playerTwo.BoardMarker || winner == _playerOne.BoardMarker)
        {
            Printer.Winner(winner);
        }
        else
        {
            Printer.TieResult();
        }
    }
}