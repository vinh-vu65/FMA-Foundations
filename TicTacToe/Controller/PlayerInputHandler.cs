using System.Text.RegularExpressions;
using System.Threading.Channels;
using TicTacToe.Models;

namespace TicTacToe.Controller;

public static class PlayerInputHandler
{
    public static string HandlePlayerTurnInput()
    {
        string? input;
        do
        {
            input = Console.ReadLine();
            if (!CoordIsValid(input))
            {
                Console.Write("Invalid input, enter co-ordinates in x,y format (ie. 2,1): ");
            }
        } while (!CoordIsValid(input));
        
        return input;
    }

    private static bool CoordIsValid(string userInput)
    {
        var pattern = $"^[1-{GameBoard.NumberOfRows}],[1-{GameBoard.NumberOfRows}]$";
        var regex = new Regex(pattern);
        return regex.IsMatch(userInput);
    }
}