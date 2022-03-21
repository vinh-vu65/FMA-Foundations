using System.Linq;
namespace BlackJack;

public class Deck
{
    public List<Card> PlayingDeck { get; set; }
    public Card NextCardToDraw { get; set; }

    public Deck()
    {
        LoadCards();
        ShuffleDeck();
    }
    private void LoadCards()
    {
        Console.WriteLine("Preparing to load deck... \n");
        PlayingDeck = new List<Card>();
        var suits = Enum.GetValues<Card.Suit>();
        var values = Enum.GetValues<Card.Value>();
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
    public void ShuffleDeck()
    {
        Console.WriteLine("Preparing to shuffle deck... \n");
        var rnd = new Random();
        var shuffledDeck = PlayingDeck.OrderBy(item => rnd.Next());
        PlayingDeck = shuffledDeck.ToList();
        Console.WriteLine("Deck has been shuffled. \n");
    }
    public void DrawFromDeck()
    {
        var deckSize = PlayingDeck.Count;
        NextCardToDraw = PlayingDeck[deckSize - 1];
        PlayingDeck.Remove(NextCardToDraw);
    }
}