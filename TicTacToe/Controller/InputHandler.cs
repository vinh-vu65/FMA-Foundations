using System.Text.RegularExpressions;
using TicTacToe.Exceptions;
using TicTacToe.Models;

namespace TicTacToe.Controller;

public class InputHandler
{
    public string PlayerTurn(int boardSize)
    {
        bool inputValid = false;
        string input = "";
        while (!inputValid)
        {
            try
            {
                input = Console.ReadLine();
                CoordIsValid(input, boardSize);
                inputValid = true;
            }
            catch(InvalidCoordinateException e)
            {
                Console.WriteLine(e.Message);
            } 
        }
        return input;
    }

    private void CoordIsValid(string userInput, int boardSize)
    {
        var pattern = $"^[1-{boardSize}],[1-{boardSize}]$";
        var regex = new Regex(pattern);
        if (!regex.IsMatch(userInput))
        {
            throw new InvalidCoordinateException();
        }
    }
}