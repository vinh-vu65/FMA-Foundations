namespace BlackJack;

public class GameApplication
{
    private readonly GameEngine _gameEngine;
    
    public GameApplication(GameEngine gameEngine)
    {
        _gameEngine = gameEngine;
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
        _gameEngine.DetermineWinner(_gameEngine.User, _gameEngine.Dealer);
        PrintWinnerMessage();
    }

    private void UserTurn()
    {
        // Deal 1 card to user pre-loop. Code in loop will deal again once, resulting in initial 2 cards in hand.
        _gameEngine.DealToPlayer(_gameEngine.User);
        do
        {
            PlayerTurnLogic(_gameEngine.User);
            if (_gameEngine.User.Bust)
            {
                return;
            }
            _gameEngine.HandleInput();
        } while (!_gameEngine.User.Stay);
    }

    private void DealerTurn()
    {
        // Deal 1 card to dealer pre-loop. Code in loop will deal again once, resulting in initial 2 cards in hand.
        _gameEngine.DealToPlayer(_gameEngine.Dealer);
        do
        {
            PlayerTurnLogic(_gameEngine.Dealer);
            if (_gameEngine.Dealer.HandValue > 17)
            {
                _gameEngine.Dealer.Stay = true;
            }
        } while (!_gameEngine.Dealer.Stay);
    }

    private void PlayerTurnLogic(IPlayer player)
    {
        _gameEngine.DealToPlayer(player);
        _gameEngine.CalculateHandValue(player);
        PrintHand(player);
        _gameEngine.CheckIfBust(player);
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
        if (_gameEngine.DealerWins)
        {
            Console.WriteLine("Dealer wins!");
        }

        if (_gameEngine.UserWins)
        {
            Console.WriteLine("You beat the dealer!");
        }

        if (_gameEngine.GameTie)
        {
            Console.WriteLine("The game has ended in a tie");
        }
    }
}