using System.Reflection;
using System.Runtime.InteropServices;
using TicTacToe.Controller;
using Xunit;

namespace TicTacToeTests.Controller;

public class InputHandlerTests
{
    [Theory]
    [InlineData("1,1", 2)]
    [InlineData("3,3", 3)]
    [InlineData("9,9", 9)]
    [InlineData("2,3", 4)]
    public void CoordIsValid_ShouldReturnTrue_WhenGivenCoordsWithinBoardSize(string input, int boardSize)
    {
        var sut = new InputHandler();
        MethodInfo methodInfo = typeof(InputHandler).GetMethod("CoordIsValid", BindingFlags.NonPublic | BindingFlags.Instance);
        object[] parameters = {input, boardSize};

        object result = methodInfo.Invoke(sut, parameters);
        
        Assert.True((bool)result);
    }
    
    [Theory]
    [InlineData("1 ,1", 2)]
    [InlineData("3, 3", 3)]
    public void CoordIsValid_ShouldReturnFalse_WhenGivenCoordsWithinBoardSize_ButIncorrectFormat(string input, int boardSize)
    {
        var sut = new InputHandler();
        MethodInfo methodInfo = typeof(InputHandler).GetMethod("CoordIsValid", BindingFlags.NonPublic | BindingFlags.Instance);
        object[] parameters = {input, boardSize};

        object result = methodInfo.Invoke(sut, parameters);
        
        Assert.False((bool)result);
    }
}