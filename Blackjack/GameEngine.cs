namespace BlackJack;

public class GameEngine
{
    public User User;
    public Deck Deck;
    private bool inputValid = false;
    public bool UserWins, DealerWins, GameTie;

    public GameEngine(User user, Deck deck)
    {
        User = user;
        Deck = deck;
    }
        // Calculate initial hand
        // Seperate value calculator and ace handling
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
        Deck.DrawFromDeck();
        player.Hand.Add(Deck.NextCardToDraw);
        Console.WriteLine($"{player} has drawn {Deck.NextCardToDraw}");
    }

    public void HandleInput()
    {
        int userChoice;
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
        if ((user.Bust && dealer.Bust) || (21 - user.HandValue == 21 - dealer.HandValue))
        {
            GameTie = true;
        }
        else if ((user.Bust && !dealer.Bust) || (21 - user.HandValue > 21 - dealer.HandValue))
        {
            DealerWins = true;
        }
        else if ((!user.Bust && dealer.Bust) || (21 - user.HandValue < 21 - dealer.HandValue))
        {
            UserWins = true;
        }
    }
}