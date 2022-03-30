using System;
using TicTacToe.Models;
using Xunit;

namespace TicTacToeTests.Models;

public class GameBoardTests
{
    [Theory]
    [InlineData(3, 9)]
    [InlineData(4, 16)]
    [InlineData(5, 25)]
    public void LoadInitialBoard_ShouldCreateCoordinates(int rows, int expectedBoardSize)
    {
        var sut = new GameBoard(rows);
        Assert.Empty(sut.BoardCoordinates);
        
        sut.LoadInitialBoard();
        
        Assert.Equal(expectedBoardSize, sut.BoardCoordinates.Count);
    }

    [Fact]
    public void LoadInitialBoard_ShouldThrowException_WhenRowSizeIsZero()
    {
        var sut = new GameBoard(0);

        Assert.Throws<Exception>(() => sut.LoadInitialBoard());
    }
}