using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameEngine
{
    private bool _isGameOver;
    private readonly GameBoardController _boardController;
    private readonly GameBoard _gameBoard;
    private readonly HumanPlayer _playerOne;
    private readonly HumanPlayer _playerTwo;
    private readonly WinChecker _winChecker;
    private readonly int _minimumMovesBeforeWin;

    public GameEngine(GameBoardController boardController, GameBoard gameBoard, HumanPlayer playerOne, 
        HumanPlayer playerTwo, WinChecker winChecker)
    {
        _boardController = boardController;
        _gameBoard = gameBoard;
        _playerOne = playerOne;
        _playerTwo = playerTwo;
        _winChecker = winChecker;
        _minimumMovesBeforeWin = 2 * _gameBoard.Size - 1;
    }

    public void RunGame()
    {
        while (!_isGameOver)
        {
            PlayerTurn(_playerOne);
            if (_gameBoard.MovesAccepted >= _minimumMovesBeforeWin)
            {
                CheckIfGameOver();
                if (_isGameOver)
                {
                    return;
                }
            }

            PlayerTurn(_playerTwo);
            if (_gameBoard.MovesAccepted >= _minimumMovesBeforeWin)
            {
                CheckIfGameOver();
            }
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

    private bool IsBoardFull()
    {
        return (_gameBoard.MovesAccepted == _gameBoard.BoardCoordinates.Count);
    }
    
    private void CheckIfGameOver()
    {
        _winChecker.PerformWinCheck();
        if (_winChecker.Winner == _playerOne.BoardMarker || _winChecker.Winner == _playerTwo.BoardMarker || IsBoardFull())
        {
            _isGameOver = true;
        }
    }

    public void PrintOutcome(string winner)
    {
        if (winner == _playerOne.BoardMarker || winner == _playerTwo.BoardMarker)
        {
            Printer.Winner(winner);
        }
        else
        {
            Printer.TieResult();
        }
    }
}