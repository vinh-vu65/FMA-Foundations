using System.Threading.Channels;
using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameEngine
{
    public GameBoardController BoardController { get; }
    public GameBoard GameBoard { get; }
    public bool IsGameOver { get; set; }
    private string _winner;

    public GameEngine(GameBoardController boardController, GameBoard gameBoard)
    {
        BoardController = boardController;
        GameBoard = gameBoard;
    }

    public void PlayerTurn(IPlayer player)
    {
        Printer.PrintPlayerTurn(player);
        var turnCoord = player.ChooseCoordinates();
        while (!BoardController.IsMoveValid(turnCoord))
        {
            Printer.PrintInvalidMove();
            turnCoord = player.ChooseCoordinates();
        }

        BoardController.UpdateBoard(turnCoord, player.BoardMarker);
        Printer.PrintAcceptedMove();
    }

    public bool IsBoardFullyUsed()
    {
        return (GameBoard.MovesAccepted == GameBoard.BoardCoordinates.Count);
    }

    public void CheckRowsForWinner()
    {
        for (int i = 0; i < GameBoard.BoardCoordinates.Count; i += GameBoard.Size)
        {
            var firstValue = GameBoard.BoardCoordinates[i].Value;
            var isWinningRow = true;
            for (int j = 1; j < GameBoard.Size; j++)
            {
                if (GameBoard.BoardCoordinates[i + j].Value != firstValue)
                {
                    isWinningRow = false;
                    break;
                }
            }

            if (isWinningRow)
            {
                _winner = firstValue;
                return;
            }
        }
    }

    public void CheckColumnsForWinner()
    {
        for (int i = 0; i < GameBoard.Size; i++)
        {
            var firstValue = GameBoard.BoardCoordinates[i].Value;
            var isWinningColumn = true;
            for (int j = GameBoard.Size; j < GameBoard.BoardCoordinates.Count; j += GameBoard.Size)
            {
                if (GameBoard.BoardCoordinates[i + j].Value != firstValue)
                {
                    isWinningColumn = false;
                    break;
                }
            }

            if (isWinningColumn)
            {
                _winner = firstValue;
                return;
            }
        }
    }

    public void CheckDiagonalForWinner()
    {
        var leftToRightDiagonal = GameBoard.BoardCoordinates[0].Value;
        var rightToLeftDiagonal = GameBoard.BoardCoordinates[GameBoard.Size - 1].Value;
        var isLeftToRightWinningDiagonal = true;
        var isRightToLeftWinningDiagonal = true;

        for (int i = 1; i < GameBoard.Size; i++)
        {
            if (rightToLeftDiagonal != GameBoard.BoardCoordinates[(i + 1) * (GameBoard.Size - 1)].Value)
            {
                isRightToLeftWinningDiagonal = false;
            }

            if (leftToRightDiagonal != GameBoard.BoardCoordinates[i * (GameBoard.Size + 1)].Value)
            {
                isLeftToRightWinningDiagonal = false;
            }
        }

        if (isLeftToRightWinningDiagonal)
        {
            _winner = leftToRightDiagonal;
        }

        if (isRightToLeftWinningDiagonal)
        {
            _winner = rightToLeftDiagonal;
        }
    }

    public void DetermineWinner()
    {
        CheckColumnsForWinner();
        CheckRowsForWinner();
        CheckDiagonalForWinner();
    }
}