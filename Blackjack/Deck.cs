using System.Linq;

namespace BlackJack;

public class Deck
{
    private List<Card> PlayingDeck { get; set; }

    public Deck()
    {
        LoadCards();
        ShuffleDeck();
    }

    private void LoadCards()
    {
        Console.WriteLine("Preparing to load deck... \n");
        PlayingDeck = new List<Card>();
        var suits = Enum.GetValues<Suit>();
        var values = Enum.GetValues<Value>();
        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                var cardToAdd = new Card(value, suit);
                PlayingDeck.Add(cardToAdd);
            }
        }

        Console.WriteLine("Standard playing deck has finished loading. \n");
    }

    private void ShuffleDeck()
    {
        Console.WriteLine("Preparing to shuffle deck... \n");
        var rnd = new Random();
        PlayingDeck = PlayingDeck.OrderBy(item => rnd.Next()).ToList();
        Console.WriteLine("Deck has been shuffled. \n");
    }

    public Card DrawFromDeck()
    {
        var deckSize = PlayingDeck.Count;
        var nextCard = PlayingDeck[deckSize - 1];
        PlayingDeck.Remove(nextCard);
        return nextCard;
    }
}