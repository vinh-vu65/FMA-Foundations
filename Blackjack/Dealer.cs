namespace BlackJack;

public class Dealer : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public bool Stay { get; set; }
    public Deck Deck;

    public Dealer(Deck deck)
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
        Console.Write("The dealer's current hand is: ");
        foreach (var card in Hand)
        {
            Console.Write(card + " ");
        }
        Console.WriteLine($"\n The dealer's hand's current total is: {HandValue}");
    }

    public void ShouldDealerStay()
    {
        Stay = (HandValue > 17) ? true : false;
    }
}