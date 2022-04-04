namespace TicTacToe.Models;

public interface IPlayer
{ 
    int MovesAccepted { get; set; }
    string BoardMarker { get; set; }
    public void ChooseCoordinates();
    public string TurnCoordinates { get; set; }
}