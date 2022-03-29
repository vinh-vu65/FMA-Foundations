using TicTacToe.Models;

namespace TicTacToe.View;

public static class Printer
{
    public static void PrintWelcome()
    {
        Console.WriteLine(Constants.WelcomeMessage);
        Console.WriteLine(Constants.InitialBoardMessage);
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
}