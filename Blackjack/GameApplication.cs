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
        InitialTurnSetup(_gameEngine.User);
        PromptUserToHitOrStay();
        while (!_gameEngine.User.Stay)
        {
            PlayerHitLogic(_gameEngine.User);
            if (_gameEngine.User.Bust || _gameEngine.User.BlackJack)
            {
                return;
            }

            PromptUserToHitOrStay();
        }
    }

    private void DealerTurn()
    {
        InitialTurnSetup(_gameEngine.Dealer);
        while (_gameEngine.Dealer.HandValue < 17)
        {
            PlayerHitLogic(_gameEngine.Dealer);
        }
    }

    private void InitialTurnSetup(IPlayer player)
    {
        _gameEngine.DealInitialHand(player);
        _gameEngine.CalculateInitialHandValue(player);
        PrintHand(player);
        _gameEngine.CheckForBlackJack(player);
    }

    private void PlayerHitLogic(IPlayer player)
    {
        _gameEngine.DealToPlayer(player);
        _gameEngine.CalculateValueAfterHit(player);
        _gameEngine.HandleAceValue(player);
        PrintHand(player);
        _gameEngine.CheckForBlackJack(player);
        _gameEngine.CheckIfBust(player);
    }

    private void PromptUserToHitOrStay()
    {
        int userChoice;
        bool inputValid = false;
        Console.WriteLine("Would you like to Hit or Stay? (Hit = 1, Stay = 2)");
        do
        {
            Int32.TryParse(Console.ReadLine(), out userChoice);
            if (userChoice == 1 || userChoice == 2)
            {
                inputValid = true;
            }
            else
            {
                Console.WriteLine("Please enter 1 to hit or 2 to stay.");
                Console.Write("Try again: ");
            }
        } while (!inputValid);

        _gameEngine.User.Stay = (userChoice == 2);
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