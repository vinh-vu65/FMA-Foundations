namespace TicTacToe.Models;

public interface IPlayer
{ 
    string BoardMarker { get; set; }
    public string ChooseCoordinates();
}