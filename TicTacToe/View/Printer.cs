using System.Threading.Channels;
using TicTacToe.Models;

namespace TicTacToe.View;

public static class Printer
{
    
    public static void Welcome()
    {
        Console.WriteLine(GameMessages.WelcomeMessage);
        Console.WriteLine(GameMessages.InitialBoardMessage);
    }

    public static void GameBoard(GameBoard gameboard)
    {
        for (int i = 0; i < gameboard.BoardCoordinates.Count; i += gameboard.Size)
        {
            for (int j = 0; j < gameboard.Size; j++)
            {
                Console.Write($"{gameboard.BoardCoordinates[i+j].Value} ");
            }

            Console.WriteLine();
        } 
    }

    public static void PlayerTurn(IPlayer player)
    {
        Console.WriteLine($"{player}'s turn, enter a coord x,y to place your {player.BoardMarker} or enter 'q' to give up: ");
    }

    public static void InvalidMove()
    {
        Console.WriteLine(GameMessages.InvalidMoveMessage);
    }

    public static void AcceptedMove()
    {
        Console.WriteLine(GameMessages.MoveAcceptedMessage);
    }

    public static void Winner(string winner)
    {
        Console.WriteLine($"Player {winner} has won the game!");
    }

    public static void TieResult()
    {
        Console.WriteLine(GameMessages.GameTieMessage);
    }
}