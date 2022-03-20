namespace BlackJack;

public class Dealer : IPlayer
{
    public List<Card> Hand { get; set; }
    public int HandValue { get; set; }
    public void Hit()
    {
        throw new NotImplementedException();
    }

    public void Stay()
    {
        throw new NotImplementedException();
    }

    public bool ShouldDealerHit()
    {
        return true;
    }
}