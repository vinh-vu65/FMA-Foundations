namespace BlackJack;

public class User : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public int AceCounter { get; set; }
    public bool Stay { get; set; }
    public bool Bust { get; set; }
    
    public User()
    {
        Hand = new List<Card>();
    }
    
    public override string ToString()
    {
        return "User";
    }
}