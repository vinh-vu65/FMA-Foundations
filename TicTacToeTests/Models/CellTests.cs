using System.Runtime.InteropServices;
using TicTacToe.Models;
using Xunit;

namespace TicTacToeTests.Models;

public class CellTests
{
    [Fact]
    public void IsUsed_ShouldReturnFalse_WhenValueIsDot()
    {
        var sut = new Cell(3, 4);
        
        Assert.False(sut.IsUsed());
    }

    [Theory]
    [InlineData("X")]
    [InlineData("O")]
    [InlineData("5")]
    [InlineData(",")]
    [InlineData("K")]
    [InlineData("k")]
    [InlineData("*")]
    public void IsUsed_ShouldReturnTrue_WhenValuePropertyIsNotDot(string newValue)
    {
        var sut = new Cell(2, 1);

        sut.Value = newValue;
        
        Assert.True(sut.IsUsed());
    }

    [Theory]
    [InlineData(3, 4, "3,4")]
    [InlineData(0, 0, "0,0")]
    [InlineData(11, 12, "11,12")]
    [InlineData(-5, 4, "-5,4")]
    [InlineData(-3, -7, "-3,-7")]
    public void ToString_ShouldReturnXYValuesSeparatedByComma(int x, int y, string expectedString)
    {
        var sut = new Cell(x, y);
        
        Assert.Equal(expectedString, sut.ToString());
    }
}