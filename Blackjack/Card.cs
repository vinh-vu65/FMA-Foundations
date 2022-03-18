namespace BlackJack;

public class Card
{
    // Card Value = number on card
    // Card Face = Value + Suit
    
    public Suit CardSuit { get; set; }
    public Value CardValue { get; set; }
    
    public Card(Value value, Suit suit)
    {
        CardValue = value;
        CardSuit = suit;
    }
    public override string ToString()
    {
        return $"[{CardValue} , {CardSuit}]";
    }
    public int GetValue()
    {
        int value = (int)CardValue;
        if (value > 11)
        {
            value = 10;
        }
        return value;
    }
    public enum Suit
    {
        HEART,
        DIAMOND,
        CLUB,
        SPADE
    }
    public enum Value
    {
        TWO = 2,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        ACE,
        JACK,
        QUEEN,
        KING
    }
}