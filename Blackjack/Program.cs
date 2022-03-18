namespace BlackJack;

public class Program
{
    public static void Main(string[] args)
    {
        Card myCard = new Card(Card.Value.QUEEN, Card.Suit.HEART);
        Console.WriteLine(myCard);
        Console.WriteLine(myCard.GetValue());

        var myDeck = new Deck();
        foreach (var card in myDeck.PlayingDeck)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine("\n Deck Load Complete, time to shuffle \n");
        myDeck.ShuffleDeck();
        foreach (var card in myDeck.PlayingDeck)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine("Let's draw a card \n");
        myDeck.DrawFromDeck();
        foreach (var card in myDeck.PlayingDeck)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine("The card I drew is \n");
        Console.WriteLine(myDeck.NextCardToDraw);
        
    }
}
