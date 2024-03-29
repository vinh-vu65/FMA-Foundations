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
    [InlineData(Value.KING)]
    [InlineData(Value.QUEEN)]
    [InlineData(Value.JACK)]
    public void WhenCardValue_IsGivenPicture_ThenValueEqualsTen(Value value)
    {
        // Arrange:
        var pictureCard = new Card(value, Suit.SPADE);

        // Act:
        var result = pictureCard.GetValue();

        //Assert:
        Assert.Equal(10, result);
    }

    [Fact]
    public void WhenCardValue_IsGivenAce_ThenValueEqualEleven()
    {
        // Arrange:
        var aceCard = new Card(Value.ACE, Suit.HEART);

        // Act:
        var result = aceCard.GetValue();

        // Assert:
        Assert.Equal(11, result);
    }

    [Fact]
    public void WhenAceIsPresentInDeck_AndHandValue_IsGivenOverBust_ThenAceValueEqualsOne()
    {
        // Arrange:
        var deck = new Deck();
        var player = new User();
        var dealer = new Dealer();
        player.Hand = new List<Card>();
        player.Hand.Add(new Card(Value.ACE, Suit.CLUB));
        player.Hand.Add(new Card(Value.JACK, Suit.SPADE));
        player.Hand.Add(new Card(Value.FIVE, Suit.SPADE));

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
    public void WhenDealerHand_IsGivenBustAndUserIsNotBust_ThenUserWins()

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
    public void WhenUserHand_IsGivenBustAndDealerIsNotBust_ThenDealerWins()

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
    public void WhenBothDealerAndUserBust_ThenGameIsATie()

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
    public void WhenNeitherUserOrDealerBust_ButUserCloserTo21_ThenUserWins()

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
    public void WhenNeitherUserOrDealerBust_ButDealerCloserTo21_ThenDealerWins()

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
    public void WhenNeitherUserOrDealerBust_ButScoresAreEqual_ThenGameIsATie()

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