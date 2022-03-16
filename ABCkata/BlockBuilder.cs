using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace ABCKata;

public class BlockBuilder
{
    public List<Block> BlocksToCheck {get; set;}
    private string userInput;
    private char userFirstValue, userSecondValue;
    private bool inputValid = false;
    private bool userChooseSample;
    private int numberOfUserBlocks;

    public BlockBuilder()
    {
        ChooseBlocksToBuild();
        BlocksToCheck = userChooseSample ? LoadSampleBlocks() : LoadUserInputBlocks();
        Console.WriteLine("-- Block loading complete -- \n");
    }
    public void ChooseBlocksToBuild()
    {
        int userChoice;
        Console.WriteLine("Would you like to load the program's sample blocks, or enter your own?");
        Console.WriteLine("Enter 1 to load sample or 2 to enter your own: ");
        do
        {
            Int32.TryParse(Console.ReadLine(), out userChoice);
            if (userChoice == 1 || userChoice == 2)
            {
                inputValid = true;
            }
            else
            {
                Console.WriteLine("Please enter 1 to load sample blocks or 2 to enter your own.");
                Console.Write("Try again: ");
            }
        } while (!inputValid);
        ResetValidCheck();
        userChooseSample = (userChoice == 1) ? true : false;
    }
    public List<Block> LoadSampleBlocks()
    {
        List<Block> sampleBlocks = new List<Block>
        {
            new Block('B', 'O'),
            new Block('X', 'K'),
            new Block('D', 'Q'),
            new Block('C', 'P'),
            new Block('N', 'A'),
            new Block('G', 'T'),
            new Block('R', 'E'),
            new Block('T', 'G'),
            new Block('Q', 'D'),
            new Block('F', 'S'),
            new Block('J', 'W'),
            new Block('H', 'U'),
            new Block('V', 'I'),
            new Block('A', 'N'),
            new Block('O', 'B'),
            new Block('E', 'R'),
            new Block('F', 'S'),
            new Block('L', 'Y'),
            new Block('P', 'C'),
            new Block('Z', 'M'),
        };
        return sampleBlocks;
    }
    public List<Block> LoadUserInputBlocks()
    {
        List<Block> userBlocks = new List<Block>();
        UserBlockQuantity();
        ResetValidCheck();
        for (int i = 0 ; i < numberOfUserBlocks ; i++)
        {
            userInput = ReadUserInput();
            var blockToAdd = ReturnBlockFromString(userInput);
            userBlocks.Add(blockToAdd);
        }
        return userBlocks;
    }
    public void UserBlockQuantity()
    {
        Console.WriteLine("Please enter the number of blocks you would like to add: ");
        do
        {
            Int32.TryParse(Console.ReadLine(), out numberOfUserBlocks);
            if (numberOfUserBlocks > 0)
            {
                inputValid = true;
            }
            else
            {
                Console.WriteLine("Input not valid, please enter a number greater than zero.");
                Console.Write("Try again: ");
            }
        } while (!inputValid);
        ResetValidCheck();
    }
    public string ReadUserInput()
    {
        string input;
        Console.Write("Please enter both block letters together (eg. AB): ");
        do
        {
            input = Console.ReadLine().ToUpper();
            if (input.Length == 2 && WordChecker.IsValid(input))
            {
                inputValid = true;
            }
            else
            {
                Console.WriteLine("Input not valid, please enter two letters for the block (eg. RG or KC)");
                Console.Write("Try again: ");
            }
        } while (!inputValid);
        ResetValidCheck();
        return input;
    }
    public Block ReturnBlockFromString(string input)
    {
        userFirstValue = input[0];
        userSecondValue = input[1];
        return new Block(userFirstValue, userSecondValue);
    }
    public void ResetValidCheck()
    {
        inputValid = false;
    }
}