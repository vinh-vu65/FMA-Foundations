using System;
namespace Foundation;

public interface IUserInputProgram
{
    public int UserChoice {get; set;}
    public void Execute();
    public void PrintInitialMessage();
}