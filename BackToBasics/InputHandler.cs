using System;
namespace Foundation;

public class InputHandler
{
    public int UserInput;
    public int HandleInput()
    {
        int userInput;
            do 
            {
                Console.WriteLine("Please enter a number greater than zero: ");
                Int32.TryParse(Console.ReadLine(), out userInput);
            } while (userInput <= 0);
            return userInput;
    }
}