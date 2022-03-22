namespace BlackJack;

public class Program
{
    public static void Main(string[] args)
    {
        GameApplication.PrintStartupMessage();
        var deck = new Deck();
        var dealer = new Dealer();
        var user = new User();
        var gameEngine = new GameEngine(user, dealer, deck);
        var gameApplication = new GameApplication(gameEngine);
        
        gameApplication.Run();
    }
}
