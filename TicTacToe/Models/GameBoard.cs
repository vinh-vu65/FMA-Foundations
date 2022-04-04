namespace TicTacToe.Models;

public class GameBoard
{
    private const int MIN_NUMBER_OF_ROWS = 3;
    public int Size { get; }
    public List<Cell> BoardCoordinates { get; }
    

    public GameBoard(int size)
    {
        Size = size;
        BoardCoordinates = new List<Cell>();
        LoadInitialBoard();
    }

    public void LoadInitialBoard()
    {
        if (Size < MIN_NUMBER_OF_ROWS)
        {
            throw new Exception();
        }
        
        for (int i = 1; i <= Size; i++)
        {
            for (int j = 1; j <= Size; j++)
            {
                var coordinateToAdd = new Cell(j, i);
                BoardCoordinates.Add(coordinateToAdd);
            }
        }
    }
}