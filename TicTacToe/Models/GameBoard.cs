namespace TicTacToe.Models;

public class GameBoard
{
    private const int MIN_NUMBER_OF_ROWS = 3;
    public List<Cell> BoardCoordinates { get; }
    public int Size { get; }
    public int MovesAccepted { get; set; }

    public GameBoard(int size)
    {
        Size = size;
        BoardCoordinates = new List<Cell>();
        LoadInitialBoard(Size);
    }

    private void LoadInitialBoard(int size)
    {
        if (size < MIN_NUMBER_OF_ROWS)
        {
            throw new Exception();
        }
        
        for (int i = 1; i <= size; i++)
        {
            for (int j = 1; j <= size; j++)
            {
                var coordinateToAdd = new Cell(j, i);
                BoardCoordinates.Add(coordinateToAdd);
            }
        }
    }
}