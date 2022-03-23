namespace BlackJack;

public interface IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public int AceCounter { get; set; }
    public bool Bust { get; set; }
}