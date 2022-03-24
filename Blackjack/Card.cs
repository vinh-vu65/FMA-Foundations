namespace BlackJack;

public class Card
{
    private readonly Suit _cardSuit;
    public Value CardValue { get; }

    public Card(Value value, Suit suit)
    {
        CardValue = value;
        _cardSuit = suit;
    }

    public override string ToString()
    {
        return $"[{CardValue} , {_cardSuit}]";
    }

    public int GetValue()
    {
        int value = (int) CardValue;
        if (value > 11)
        {
            value = 10;
        }

        return value;
    }
}