namespace BlackJack;

public class GameEngine
{
    public User User { get; }
    public Dealer Dealer { get; }
    private readonly Deck _deck;
    public bool UserWins { get; private set; }
    public bool DealerWins { get; private set; }
    public bool GameTie { get; private set; }

    public GameEngine(User user, Dealer dealer, Deck deck)
    {
        User = user;
        Dealer = dealer;
        _deck = deck;
    }

    public void CalculateInitialHandValue(IPlayer player)
    {
        int value = 0;
        foreach (var card in player.Hand)
        {
            value += card.GetValue();
            if (card.CardValue == Value.ACE)
            {
                player.AceCounter++;
            }
        }

        player.HandValue = value;
    }

    public void CalculateValueAfterHit(IPlayer player)
    {
        var handSize = player.Hand.Count;
        var drawnCard = player.Hand[handSize - 1];
        var drawnCardValue = drawnCard.GetValue();
        if (drawnCard.CardValue == Value.ACE)
        {
            player.AceCounter++;
        }

        player.HandValue += drawnCardValue;
    }

    public void HandleAceValue(IPlayer player)
    {
        while (player.AceCounter > 0 && player.HandValue > 21)
        {
            player.AceCounter--;
            player.HandValue -= 10;
        }
    }

    public void DealToPlayer(IPlayer player)
    {
        var nextCard = _deck.DrawFromDeck();
        player.Hand.Add(nextCard);
        Console.WriteLine($"{player} has drawn {nextCard}");
    }

    public void DealInitialHand(IPlayer player)
    {
        for (int i = 0; i < 2; i++)
        {
            DealToPlayer(player);
        }
    }

    public void CheckIfBust(IPlayer player)
    {
        if (player.HandValue > 21)
        {
            player.Bust = true;
            Console.WriteLine($"{player} has bust.");
        }
    }

    public void CheckForBlackJack(IPlayer player)
    {
        if (player.HandValue == 21)
        {
            player.BlackJack = true;
            Console.WriteLine($"{player} has BlackJack");
        }
    }

    public void DetermineWinner(User user, Dealer dealer)
    {
        bool neitherBust = !user.Bust && !dealer.Bust;

        if ((user.Bust && dealer.Bust) || (neitherBust && (21 - user.HandValue == 21 - dealer.HandValue)) ||
            user.BlackJack && dealer.BlackJack)
        {
            GameTie = true;
        }
        else if ((user.Bust && !dealer.Bust) || (neitherBust && (21 - user.HandValue > 21 - dealer.HandValue)) ||
                 !user.BlackJack && dealer.BlackJack)
        {
            DealerWins = true;
        }
        else if ((!user.Bust && dealer.Bust) || (neitherBust && (21 - user.HandValue < 21 - dealer.HandValue)) ||
                 user.BlackJack && !dealer.BlackJack)
        {
            UserWins = true;
        }
    }
}