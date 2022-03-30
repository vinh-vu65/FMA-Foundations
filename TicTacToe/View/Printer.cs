using System.Threading.Channels;
using TicTacToe.Models;

namespace TicTacToe.View;

public static class Printer
{
    
    public static void PrintWelcome()
    {
        Console.WriteLine(GameMessages.WelcomeMessage);
        Console.WriteLine(GameMessages.InitialBoardMessage);
    }

    public static void PrintBoard(GameBoard gameboard)
    {
        for (int i = 0; i < gameboard.BoardCoordinates.Count; i += gameboard.NumberOfColumns)
        {
            for (int j = 0; j < gameboard.NumberOfColumns; j++)
            {
                Console.Write($"{gameboard.BoardCoordinates[i+j].Value} ");
            }

            Console.WriteLine();
        } 
    }

    public static void PrintPlayerTurn(IPlayer player)
    {
        Console.WriteLine($"{player}'s turn, enter a coord x,y to place your {player.BoardMarker} or enter 'q' to give up: ");
    }

    public static void PrintInvalidMove()
    {
        Console.WriteLine(GameMessages.InvalidMoveMessage);
    }
}