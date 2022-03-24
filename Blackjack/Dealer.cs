namespace BlackJack;

public class Dealer : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public int AceCounter { get; set; }
    public bool Bust { get; set; }
    public bool BlackJack { get; set; }

    public Dealer()
    {
        Hand = new List<Card>();
    }

    public override string ToString()
    {
        return "Dealer";
    }
}