using TicTacToe.Controller;
using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        var inputHandler = new InputHandler();
        Printer.PrintWelcome();

        var gameBoard = new GameBoard(GameMessages.DefaultNumberOfRows);
        Printer.PrintBoard(gameBoard);
        var playerX = new HumanPlayer("X", gameBoard, inputHandler);
        var playerO = new HumanPlayer("O", gameBoard, inputHandler);
        var controller = new GameBoardController(gameBoard);

        var flowController = new GameFlowController(controller, gameBoard);

        while (!flowController.Quit)
        {
            flowController.PlayerTurn(playerX);
        
            Printer.PrintBoard(gameBoard);

            if (flowController.IsBoardFullyUsed())
            {
                flowController.Quit = true;
                return;
            }

            flowController.PlayerTurn(playerO);
        
            Printer.PrintBoard(gameBoard);
            
            if (flowController.IsBoardFullyUsed())
            {
                flowController.Quit = true;
                return;
            }
        }
        
    }
}



