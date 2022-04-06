using System.Runtime.InteropServices;
using TicTacToe.Controller;
using TicTacToe.Models;
using Xunit;

namespace TicTacToeTests.Controller;

public class BoardControllerTests
{
    [Theory]
    [InlineData("4,4")]
    [InlineData("1,1")]
    [InlineData("2,3")]
    [InlineData("1,4")]
    public void IsMoveValid_ShouldReturnTrue_WhenCellIsNotYetUsed(string coordinates)
    {
        var gb = new GameBoard(4);
        var sut = new GameBoardController(gb);
        
        Assert.True(sut.IsMoveValid(coordinates));
    }

    [Theory]
    [InlineData(0, "1,1")]
    [InlineData(1, "2,1")]
    [InlineData(2, "3,1")]
    [InlineData(3, "1,2")]
    [InlineData(4, "2,2")]
    [InlineData(5, "3,2")]
    [InlineData(6, "1,3")]
    [InlineData(7, "2,3")]
    [InlineData(8, "3,3")]
    public void IsMoveValid_ShouldReturnFalse_WhenCellIsAlreadyUsed(int cooordinateIndex, string coordinate)
    {
        var gb = new GameBoard(3);
        gb.BoardCoordinates[cooordinateIndex].Value = "x";
        var sut = new GameBoardController(gb);
        
        Assert.False(sut.IsMoveValid(coordinate));
    }

    [Theory]
    [InlineData(0, "1,1", "X")]
    [InlineData(0, "1,1", "O")]
    [InlineData(0, "1,1", "K")]
    [InlineData(0, "1,1", "7")]
    [InlineData(3, "1,2", "X")]
    [InlineData(8, "3,3", ":")]
    [InlineData(5, "3,2", "@")]
    [InlineData(4, "2,2", "OO")]

    public void UpdateBoard_SetsCoordinateValue_ToBoardMarkerValue(int index, string coordinates, string boardMarker)
    {
        var gb = new GameBoard(3);
        var sut = new GameBoardController(gb);
        Assert.Equal(".", gb.BoardCoordinates[index].Value);
        
        sut.UpdateBoard(coordinates, boardMarker);
        
        Assert.Equal(boardMarker, gb.BoardCoordinates[index].Value);
    }

    [Fact]
    public void UpdateBoard_IncrementsGameBoardMovesAcceptedByOne()
    {
        var gb = new GameBoard(3);
        var sut = new GameBoardController(gb);
        gb.MovesAccepted = 4;
        
        sut.UpdateBoard("1,1", "D");
        
        Assert.Equal(5, gb.MovesAccepted);
    }
}