using System.Threading.Channels;
using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameEngine
{
    public GameBoardController BoardController { get; }
    public GameBoard GameBoard { get; }
    public HumanPlayer PlayerOne { get; }
    public HumanPlayer PlayerTwo { get; }
    public bool IsGameOver { get; private set; }
    public string Winner { get; private set; }

    public GameEngine(GameBoardController boardController, GameBoard gameBoard, HumanPlayer playerOne, HumanPlayer playerTwo)
    {
        BoardController = boardController;
        GameBoard = gameBoard;
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
    }

    public void RunGame()
    {
        PlayerTurn(PlayerOne);
        if (GameBoard.MovesAccepted >= 2 * GameBoard.Size - 1) // Minimum number of moves before winner can be determined
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
        PlayerTurn(PlayerTwo);
        if (GameBoard.MovesAccepted >= 2 * GameBoard.Size - 1)
        {
            DetermineWinner();
        }
    }

    private void PlayerTurn(IPlayer player)
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
        Printer.PrintBoard(GameBoard);
    }

    private bool IsGameTied()
    {
        return (GameBoard.MovesAccepted == GameBoard.BoardCoordinates.Count);
    }

    private void CheckRowsForWinner()
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
                Winner = firstValue;
                return;
            }
        }
    }

    private void CheckColumnsForWinner()
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
        
        var leftToRightDiagonal = GameBoard.BoardCoordinates[0].Value;
        var rightToLeftDiagonal = GameBoard.BoardCoordinates[GameBoard.Size - 1].Value;
        var isLeftToRightWinningDiagonal = true;
        var isRightToLeftWinningDiagonal = true;

        for (int i = 1; i < GameBoard.Size; i++)
        {
            if (rightToLeftDiagonal != GameBoard.BoardCoordinates[(i + 1) * (GameBoard.Size - 1)].Value)
            {
                isRightToLeftWinningDiagonal = false;
                break;
            }

            if (leftToRightDiagonal != GameBoard.BoardCoordinates[i * (GameBoard.Size + 1)].Value)
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
        if (Winner == PlayerTwo.BoardMarker || Winner == PlayerOne.BoardMarker)
        {
            IsGameOver = true;
        }
    }

    public void PrintOutcome(string winner)
    {
        if (winner == PlayerTwo.BoardMarker || winner == PlayerOne.BoardMarker)
        {
            Printer.PrintWinner(winner);
        }
        else
        {
            Printer.PrintTieResult();
        }
    }
}