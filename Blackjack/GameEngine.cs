namespace BlackJack;

public class GameEngine
{
    // DetermineWinner()
    // CalculateHandValue() -> Ace = 11, if hand > 21 and Hand.Contains(Ace), ace value = 1
    public List<Card> PlayingDeck;
    public Deck Deck;
    public User User;
    public Dealer Dealer;
    private bool inputValid;

    public GameEngine(User user)
    {
        User = user;
    }

    public void CalculateHandValue(IPlayer player)
    {
        int value = 0;
        foreach (var card in player.Hand)
        {
            value += card.GetValue();
        }

        player.HandValue = value;
    }

    /*
    public void DealToPlayer(IPlayer player)
    {
        Deck.DrawFromDeck();s
        player.Hand.Add(Deck.NextCardToDraw);
    }

    public void DealInitialHand(IPlayer player)
    {
        for (int i = 0; i < 2; i++)
        {
            DealToPlayer(player);
        }
    }
    */

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
}