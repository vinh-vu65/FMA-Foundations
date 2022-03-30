namespace TicTacToe.Models;

public class GameBoard
{
    public static int NumberOfRows { get; set; }
    public int NumberOfColumns;
    public List<Cell> BoardCoordinates;

    public GameBoard(int numberOfRows)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfRows;
        BoardCoordinates = new List<Cell>();
    }

    public void LoadInitialBoard()
    {
        if (NumberOfRows == 0)
        {
            throw new Exception();
        }
        
        for (int i = 1; i <= NumberOfRows; i++)
        {
            for (int j = 1; j <= NumberOfColumns; j++)
            {
                var coordinateToAdd = new Cell(j, i);
                BoardCoordinates.Add(coordinateToAdd);
            }
        }
    }
}