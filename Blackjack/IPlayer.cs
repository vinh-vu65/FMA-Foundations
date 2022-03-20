namespace BlackJack;

public interface IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public void Hit();
    public void Stay();
}