namespace TicTacToe.Models;

public class GameBoard
{
    public int NumberOfRows { get; set; }
    public int NumberOfColumns;
    public List<Coordinates> BoardCoordinates;

    public GameBoard(int numberOfRows)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfRows;
        BoardCoordinates = new List<Coordinates>();
    }

    public void LoadInitialBoard()
    {
        for (int i = 1; i <= NumberOfRows; i++)
        {
            for (int j = 1; j <= NumberOfColumns; j++)
            {
                var coordinateToAdd = new Coordinates(j, i);
                BoardCoordinates.Add(coordinateToAdd);
            }
        }
    }
}