namespace BlackJack;

public interface IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public bool Stay { get; set; }
    public bool Bust { get; set; }
}