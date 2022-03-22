namespace BlackJack;

public class GameEngine
{
    public User User { get; }
    public Dealer Dealer { get; }
    private readonly Deck _deck;
    public bool UserWins;
    public bool DealerWins;
    public bool GameTie;

    public GameEngine(User user, Dealer dealer, Deck deck)
    {
        User = user;
        Dealer = dealer;
        _deck = deck;
    }
    
    // Ace counter to Hand property
    // Deal intial hand method
    // Calculate Initial hand value
    // Add Card value and calculate
    public void CalculateHandValue(IPlayer player)
    {
        int value = 0;
        int aceCounter = 0;
        foreach (var card in player.Hand)
        {
            value += card.GetValue();
            if (card.CardValue == Card.Value.ACE)
            {
                aceCounter++;
            }
        }

        while (value > 21 && aceCounter > 0)
        {
            value -= 10;
            aceCounter--;
        }
        player.HandValue = value;
    }
    
    public void DealToPlayer(IPlayer player)
    {
        _deck.DrawFromDeck();
        player.Hand.Add(_deck.NextCardToDraw);
        Console.WriteLine($"{player} has drawn {_deck.NextCardToDraw}");
    }

    public void HandleInput()
    {
        int userChoice;
        bool inputValid = false;
        Console.WriteLine("Would you like to Hit or Stay? (Hit = 1, Stay = 2)");
        do
        {
            Int32.TryParse(Console.ReadLine(), out userChoice);
            if (userChoice == 1 || userChoice == 2)
            {
                inputValid = true;
            }
            else
            {
                Console.WriteLine("Please enter 1 to hit or 2 to stay.");
                Console.Write("Try again: ");
            }
        } while (!inputValid);

        if (userChoice == 2)
        {
            User.Stay = true;
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
    
    public void DetermineWinner(User user, Dealer dealer)
    {
        bool neitherBust = !user.Bust && !dealer.Bust;
        
        if ((user.Bust && dealer.Bust) || ((neitherBust) && (21 - user.HandValue == 21 - dealer.HandValue)))
        {
            GameTie = true;
        }
        else if ((user.Bust && !dealer.Bust) || ((neitherBust) && (21 - user.HandValue > 21 - dealer.HandValue)))
        {
            DealerWins = true;
        }
        else if ((!user.Bust && dealer.Bust) || ((neitherBust) && (21 - user.HandValue < 21 - dealer.HandValue)))
        {
            UserWins = true;
        }
    }
}