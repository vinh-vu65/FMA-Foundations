using System.Text.RegularExpressions;
using TicTacToe.Exceptions;
using TicTacToe.Models;

namespace TicTacToe.Controller;

public class InputHandler
{
    public string ReadUserInput()
    {
        var output = Console.ReadLine();
        output = output.Trim();
        return output;
    }

    public bool ValidateTurn(string userInput, int boardSize)
    {
        try
        {
            ValidateCoordinateValues(userInput, boardSize);
            ValidateCoordinateFormat(userInput, boardSize);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }

    private void ValidateCoordinateFormat(string userInput, int boardSize)
    {
        var pattern = $"^[1-{boardSize}],[1-{boardSize}]$";
        var regex = new Regex(pattern);
        if (!regex.IsMatch(userInput))
        {
            throw new InvalidCoordinateFormatException();
        }
    }

    private void ValidateCoordinateValues(string userInput, int boardSize)
    {
        int firstValue, secondValue;
        firstValue = int.Parse(userInput[0].ToString());
        secondValue = int.Parse(userInput[^1].ToString());
        if (firstValue < 1 || firstValue > boardSize || secondValue < 1 || secondValue > boardSize)
        {
            throw new OutOfBoundsException(boardSize);
        }
    }
}