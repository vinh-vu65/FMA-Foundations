using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Text.RegularExpressions;
using BlackJack;
using Xunit;

namespace BlackJackTests;

public class TestCardValue
{
    [Theory]
    [InlineData(Card.Value.KING)]
    [InlineData(Card.Value.QUEEN)]
    [InlineData(Card.Value.JACK)]
    public void WhenCardValueIsGivenPictureThenValueEqualsTen(Card.Value value)
    {
        // Arrange:
        var pictureCard = new Card(value, Card.Suit.SPADE);

        // Act:
        var result = pictureCard.GetValue();

        //Assert:
        Assert.Equal(10, result);
        
        // When, Given, Then
    }

    [Fact]
    public void WhenCardValueIsGivenAceThenValueEqualEleven()
    {
        // Arrange:
        var aceCard = new Card(Card.Value.ACE, Card.Suit.HEART);
        
        // Act:
        var result = aceCard.GetValue();
        
        // Assert:
        Assert.Equal(11, result);
    }
    [Fact]
    public void WhenAceIsPresentInDeckAndHandValueIsGivenOverBustThenAceValueEqualsOne()
    {
        // Arrange:
        var deck = new Deck();
        var player = new User();
        var dealer = new Dealer();
        player.Hand = new List<Card>();
        player.Hand.Add(new Card(Card.Value.ACE, Card.Suit.CLUB));
        player.Hand.Add(new Card(Card.Value.JACK, Card.Suit.SPADE));
        player.Hand.Add(new Card(Card.Value.FIVE, Card.Suit.SPADE));

        var engine = new GameEngine(player, dealer, deck);

        // Act:
        engine.CalculateInitialHandValue(player);
        engine.HandleAceValue(player);
        var result = player.HandValue;

        // Assert:
        Assert.Equal(16, result);
    }
}

public class TestGameWinnerLogic
{
    [Fact]
    public void WhenDealerHandIsGivenBustAndUserIsNotBustThenUserWins()

    {
        // Arrange: 
        var dealer = new Dealer();
        dealer.HandValue = 22;
        var user = new User();
        user.HandValue = 20;
        var deck = new Deck();
        var engine = new GameEngine(user, dealer, deck);
        
        // Act:
        engine.CheckIfBust(dealer);
        engine.CheckIfBust(user);
        engine.DetermineWinner(user, dealer);
        var result = engine.UserWins;
        
        // Assert:
        Assert.True(result);
    }
    
    [Fact]
    public void WhenUserHandIsGivenBustAndDealerIsNotBustThenDealerWins()

    {
        // Arrange: 
        var dealer = new Dealer();
        dealer.HandValue = 3;
        var user = new User();
        user.HandValue = 22;
        var deck = new Deck();
        var engine = new GameEngine(user, dealer, deck);
        
        // Act:
        engine.CheckIfBust(dealer);
        engine.CheckIfBust(user);
        engine.DetermineWinner(user, dealer);
        var result = engine.DealerWins;
        
        // Assert:
        Assert.True(result);
    }
    [Fact]
    public void WhenBothDealerAndUserBustThenGameIsATie()

    {
        // Arrange: 
        var dealer = new Dealer();
        dealer.HandValue = 22;
        var user = new User();
        user.HandValue = 23;
        var deck = new Deck();
        var engine = new GameEngine(user, dealer, deck);
        
        // Act:
        engine.CheckIfBust(dealer);
        engine.CheckIfBust(user);
        engine.DetermineWinner(user, dealer);
        var result = engine.GameTie;
        
        // Assert:
        Assert.True(result);
    }

    [Fact]
    public void WhenNeitherUserOrDealerBustButUserCloserTo21ThenUserWins()

    {
        // Arrange: 
        var dealer = new Dealer();
        dealer.HandValue = 19;
        var user = new User();
        user.HandValue = 20;
        var deck = new Deck();
        var engine = new GameEngine(user, dealer, deck);
        
        // Act:
        engine.CheckIfBust(dealer);
        engine.CheckIfBust(user);
        engine.DetermineWinner(user, dealer);
        var result = engine.UserWins;
        
        // Assert:
        Assert.True(result);
    }
    [Fact]
    public void WhenNeitherUserOrDealerBustButDealerCloserTo21ThenDealerWins()

    {
        // Arrange: 
        var dealer = new Dealer();
        dealer.HandValue = 2;
        var user = new User();
        user.HandValue = 1;
        var deck = new Deck();
        var engine = new GameEngine(user, dealer, deck);
        
        // Act:
        engine.CheckIfBust(dealer);
        engine.CheckIfBust(user);
        engine.DetermineWinner(user, dealer);
        var result = engine.DealerWins;
        
        // Assert:
        Assert.True(result);
    }
    
    [Fact]
    public void WhenNeitherUserOrDealerBustButScoresAreEqualThenGameIsATie()

    {
        // Arrange: 
        var dealer = new Dealer();
        dealer.HandValue = 20;
        var user = new User();
        user.HandValue = 20;
        var deck = new Deck();
        var engine = new GameEngine(user, dealer, deck);
        
        // Act:
        engine.CheckIfBust(dealer);
        engine.CheckIfBust(user);
        engine.DetermineWinner(user, dealer);
        var result = engine.GameTie;
        
        // Assert:
        Assert.True(result);
    }
}
