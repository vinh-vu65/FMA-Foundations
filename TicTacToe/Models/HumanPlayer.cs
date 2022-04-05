using TicTacToe.Controller;
using TicTacToe.View;

namespace TicTacToe.Models;

public class HumanPlayer : IPlayer
{
    public string BoardMarker { get; set; }
    public InputHandler InputHandler { get; }
    public GameBoard GameBoard { get; }

    public HumanPlayer(string boardMarker, GameBoard gameBoard, InputHandler inputHandler)
    {
        BoardMarker = boardMarker;
        GameBoard = gameBoard;
        InputHandler = inputHandler;
    }
    
    public string ChooseCoordinates()
    {
        string playerTurn;
        bool isInputValid;
        do
        {
            playerTurn = InputHandler.GetPlayerTurn();
            isInputValid = InputHandler.ValidateTurn(playerTurn, GameBoard.Size);
        } while (!isInputValid);

        return playerTurn;
    }

    public override string ToString()
    {
        return $"Player {BoardMarker}";
    }
}