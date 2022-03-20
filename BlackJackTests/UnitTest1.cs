using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Text.RegularExpressions;
using BlackJack;
using Xunit;

namespace BlackJackTests;

public class UnitTest1
{
    [Theory]
    [InlineData(Card.Value.KING)]
    [InlineData(Card.Value.QUEEN)]
    [InlineData(Card.Value.JACK)]
    public void PictureCardReturnValueOf10(Card.Value value)
    {
        // Arrange:
        var pictureCard = new Card(value, Card.Suit.SPADE);

        // Act:
        var result = pictureCard.GetValue();

        //Assert:
        Assert.Equal(10, result);
        
        // When, Given, Then
    }
}
/*
public class UnitTest2
{
    [Fact]
    public void AceValueEqualsOneWhenBust()
    {
        // Arrange:
        var player = new User()
        player.Hand = new List<Card>();
        player.Hand.Add(new Card(Card.Value.ACE, Card.Suit.CLUB));
        player.Hand.Add(new Card(Card.Value.JACK, Card.Suit.SPADE));
        player.Hand.Add(new Card(Card.Value.FIVE, Card.Suit.SPADE));

        var engine = new GameEngine();

        // Act:
        var result = engine.CalculateHandValue(player);

        // Assert:
        Assert.Equal(16, result);
    }
}
*/