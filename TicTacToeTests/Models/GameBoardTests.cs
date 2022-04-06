using System;
using System.Runtime.InteropServices;
using TicTacToe.Models;
using Xunit;

namespace TicTacToeTests.Models;

public class GameBoardTests
{
    [Theory]
    [InlineData(3, 9)]
    [InlineData(4, 16)]
    [InlineData(5, 25)]
    public void LoadInitialBoard_ShouldCreateCoordinatesInSquareOfRowSize(int rows, int expectedBoardSize)
    {
        var sut = new GameBoard(rows);

        Assert.Equal(expectedBoardSize, sut.BoardCoordinates.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(-1)]
    public void CreatingGameBoard_ShouldThrowException_WhenRowSizeIsLessThanMinimumSize(int size)
    {
        
        Assert.Throws<Exception>(() => new GameBoard(size));
    }
}