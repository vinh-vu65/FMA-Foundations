namespace BlackJack;

public class User : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public bool Stay { get; set; }
    public Deck Deck;
    

    public User(Deck deck)
    {
        Hand = new List<Card>();
        Deck = deck;
    }
    
    public void Hit()
    {
        Deck.DrawFromDeck();
        Hand.Add(Deck.NextCardToDraw);
    }

    public void PrintHand()
    {
        Console.Write("Your current hand is: ");
        foreach (var card in Hand)
        {
            Console.Write(card + " ");
        }
    }

    public void PrintHandValue()
    {
        Console.WriteLine($"Your hand's current total is: {HandValue}");
    }
}