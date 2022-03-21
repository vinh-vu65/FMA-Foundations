namespace BlackJack;

public class Program
{
    public static void Main(string[] args)
    {
        var gameApplication = new GameApplication();
        
        
        var dealer = new Dealer();
        
        
        gameApplication.PrintStartupMessage();
        var deck = new Deck();
        var user = new User(deck);
        var gameEngine = new GameEngine(user);
        
        // User hit once to get a card, user will hit again in do/while loop to get initial 2 cards
        user.Hit();
        
        do
        {
            user.Hit();
            user.PrintHand();
            gameEngine.CalculateHandValue(user);
            user.PrintHandValue();
            gameEngine.HandleInput();
        } while (!user.Stay);
        
    }
}
