namespace BlackJack;

public class Dealer : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public bool Stay { get; set; }
    public void Hit()
    {
        throw new NotImplementedException();
    }

    public void ShouldDealerStay()
    {
        Stay = (HandValue > 17) ? true : false;
    }
}