using TicTacToe.Controller;
using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        var inputHandler = new InputHandler();
        Printer.Welcome();

        var gameBoard = new GameBoard(GameMessages.DEFAULT_NUMBER_OF_ROWS);
        Printer.GameBoard(gameBoard);
        var playerX = new HumanPlayer("X", gameBoard, inputHandler);
        var playerO = new HumanPlayer("O", gameBoard, inputHandler);
        var controller = new GameBoardController(gameBoard);
        var winChecker = new WinChecker(gameBoard);

        var engine = new GameEngine(controller, gameBoard, playerX, playerO, winChecker);
        
        engine.RunGame();

        engine.PrintOutcome(winChecker.Winner);
    }
}