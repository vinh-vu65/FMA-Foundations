﻿using TicTacToe.Controller;
using TicTacToe.Models;
using TicTacToe.View;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        var inputHandler = new InputHandler();
        Printer.PrintWelcome();

        var gameBoard = new GameBoard(GameMessages.DEFAULT_NUMBER_OF_ROWS);
        Printer.PrintBoard(gameBoard);
        var playerX = new HumanPlayer("X", gameBoard, inputHandler);
        var playerO = new HumanPlayer("O", gameBoard, inputHandler);
        var controller = new GameBoardController(gameBoard);

        var engine = new GameEngine(controller, gameBoard, playerX, playerO);

        while (!engine.IsGameOver)
        {
            engine.RunGame();
        }
        
        engine.PrintOutcome(engine.Winner);
    }
}