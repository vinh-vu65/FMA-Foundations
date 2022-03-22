namespace BlackJack;

public class GameApplication
{
    public User User;
    public Dealer Dealer;
    public GameEngine GameEngine;
    
    public GameApplication(User user, Dealer dealer, GameEngine gameEngine)
    {
        User = user;
        Dealer = dealer;
        GameEngine = gameEngine;
    }

    public static void PrintStartupMessage()
    {
        Console.WriteLine("Welcome to the BlackJack Program");
        Console.WriteLine("In this program you will be playing BlackJack against the dealer");
        Console.WriteLine("You will be dealt two cards:");
        Console.WriteLine(" - Number cards are worth their number");
        Console.WriteLine(" - Picture cards are worth 10");
        Console.WriteLine(" - Ace is worth 1 or 11 \n");
        Console.WriteLine("The aim of the game is to add cards to your hand so that your cards get as close to 21 " +
                          "as possible, without going over");
        Console.WriteLine("The game will now begin loading... \n");
    }

    public void Run()
    {
        UserTurn();
        DealerTurn();
        GameEngine.DetermineWinner(User, Dealer);
        PrintWinnerMessage();
    }
    
    public void UserTurn()
    {
        // Deal 1 card to user pre-loop. Code in loop will deal again once, resulting in initial 2 cards in hand.
        GameEngine.DealToPlayer(User);
        do
        {
            PlayerTurnLogic(User);
            if (User.Bust)
            {
                return;
            }
            GameEngine.HandleInput();
        } while (!User.Stay);
    }

    public void DealerTurn()
    {
        // Deal 1 card to dealer pre-loop. Code in loop will deal again once, resulting in initial 2 cards in hand.
        GameEngine.DealToPlayer(Dealer);
        do
        {
            PlayerTurnLogic(Dealer);
            if (Dealer.HandValue > 17)
            {
                Dealer.Stay = true;
            }
        } while (!Dealer.Stay);
    }

    public void PlayerTurnLogic(IPlayer player)
    {
        GameEngine.DealToPlayer(player);
        GameEngine.CalculateHandValue(player);
        PrintHand(player);
        GameEngine.CheckIfBust(player);
    }

    private void PrintHand(IPlayer player)
    {
        Console.Write($"{player}'s current hand is: ");
        foreach (var card in player.Hand)
        {
            Console.Write(card + " ");
        }
        Console.WriteLine($"\n{player}'s current total is: {player.HandValue}");
    }

    private void PrintWinnerMessage()
    {
        if (GameEngine.DealerWins)
        {
            Console.WriteLine("Dealer wins!");
        }

        if (GameEngine.UserWins)
        {
            Console.WriteLine("You beat the dealer!");
        }

        if (GameEngine.GameTie)
        {
            Console.WriteLine("The game has ended in a tie");
        }
    }
}