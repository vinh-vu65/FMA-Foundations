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
}