using TicTacToe.Controller;
using TicTacToe.View;

namespace TicTacToe.Models;

public class HumanPlayer : IPlayer
{
    public string BoardMarker { get; set; }
    private readonly InputHandler _inputHandler;
    private readonly GameBoard _gameBoard;

    public HumanPlayer(string boardMarker, GameBoard gameBoard, InputHandler inputHandler)
    {
        BoardMarker = boardMarker;
        _gameBoard = gameBoard;
        _inputHandler = inputHandler;
    }
    
    public string ChooseCoordinates()
    {
        string playerTurn;
        bool isInputValid;
        do
        {
            playerTurn = _inputHandler.ReadUserInput();
            isInputValid = _inputHandler.ValidateTurn(playerTurn, _gameBoard.Size);
        } while (!isInputValid);

        return playerTurn;
    }

    public override string ToString()
    {
        return $"Player {BoardMarker}";
    }
}