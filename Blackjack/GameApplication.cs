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
    public GameEngine GameEngine;
    public GameApplication()
    {
        GameEngine = new GameEngine();
    }

    public void Run()
    {
        PrintStartupMessage();
    }
    public void PrintStartupMessage()
    {
        Console.WriteLine("Welcome to the BlackJack Program");
    }
}