namespace BlackJack;

public class Dealer : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public bool Stay { get; set; }
    public bool Bust { get; set; }
    
    public Dealer()
    {
        Hand = new List<Card>();
    }

    public void ShouldDealerStay()
    {
        Stay = (HandValue > 17) ? true : false;
    }
}