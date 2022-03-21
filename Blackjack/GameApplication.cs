namespace BlackJack;

public class GameApplication
{
    // Print welcome and start up
    // Load game engine -> load a deck and shuffle
    // User is given a hand of 2 cards -> PrintHand + value
    // PrintOptions() -> Hit() = [player draw from deck] or Stay()
    // HandleInput()
    // If Stay() -> Load dealer cards
    // Dealer automatically hit if value < 17.
    // Determine Winner
    // Print Winner message
    public User User;
    public Dealer Dealer;
    public GameEngine GameEngine;
    public GameApplication()
    {
        
    }
    

    public void PrintStartupMessage()
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
}