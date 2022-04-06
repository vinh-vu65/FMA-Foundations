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
            ValidateCoordinateFormat(userInput);
            ValidateCoordinateValues(userInput, boardSize);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }

    private void ValidateCoordinateFormat(string userInput)
    {
        var pattern = $"^([-\\d])+,([-\\d])+$";
        var regex = new Regex(pattern);
        if (!regex.IsMatch(userInput))
        {
            throw new InvalidCoordinateFormatException();
        }
    }

    private void ValidateCoordinateValues(string userInput, int boardSize)
    {
        var seperatedXY = userInput.Split(",");
        var xValue = int.Parse(seperatedXY[0]);
        var yValue = int.Parse(seperatedXY[1]);
        if (xValue < 1 || xValue > boardSize || yValue < 1 || yValue > boardSize)
        {
            throw new OutOfBoundsException(boardSize);
        }
    }
}