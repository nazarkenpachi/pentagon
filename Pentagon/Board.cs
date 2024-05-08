namespace Pentagon;

public abstract class Board
{
    protected readonly char[,] _grid;
    
    public int Rows { get; }
    
    public int Columns { get; }

    public char this[int r, int c]
    {
        get => _grid[r, c];
        set => _grid[r, c] = value;
    }

    public Board (int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _grid = new char[rows, columns];
    }
}