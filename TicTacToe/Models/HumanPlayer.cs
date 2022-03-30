namespace TicTacToe.Models;

public class HumanPlayer : IPlayer
{
    public int MovesAccepted { get; set; }
    public string BoardMarker { get; set; } = "X";
    

    public void ChooseCoord()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return "Player X";
    }
}