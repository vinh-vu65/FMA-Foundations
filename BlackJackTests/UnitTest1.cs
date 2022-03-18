using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Text.RegularExpressions;
using BlackJack;
using Xunit;

namespace BlackJackTests;

public class UnitTest1
{
    [Fact]
    public void PictureCardReturnValueOf10()
    {
        // Arrange:
        var pictureCard = new Card(Card.Value.KING, Card.Suit.SPADE);

        // Act:
        var result = pictureCard.GetValue();

        //Assert:
        Assert.Equal(10, result);
    }
}