namespace BlackJack;

public class Program
{
    public static void Main(string[] args)
    {
        var gameApplication = new GameApplication();
        gameApplication.PrintStartupMessage();
        var deck = new Deck();
        var dealer = new Dealer(deck);
        
        var user = new User(deck);
        var gameEngine = new GameEngine(user);
        
        // User hit once to get a card, user will hit again in do/while loop to get initial 2 cards
        user.Hit();
        
        do
        {
            user.Hit();
            gameEngine.CalculateHandValue(user);
            user.PrintHand();
            gameEngine.HandleInput();
        } while (!user.Stay);
        
        dealer.Hit();
        do
        {
            dealer.Hit();
            gameEngine.CalculateHandValue(dealer);
            dealer.PrintHand();
            if (dealer.HandValue > 17)
            {
                dealer.Stay = true;
            }
        } while (!dealer.Stay);
    }
}
