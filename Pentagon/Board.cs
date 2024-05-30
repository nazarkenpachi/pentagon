using System;

namespace Pentagon;

public class Board
{
    private int FilledCells { get; }
    
    private readonly char[,] _grid;
    
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
        SetRandomGrid();
        FilledCells = CountFilledCells();
    }
    public bool IsInsideGrid(int r, int c)
    {
        return r >= 0 && r < Rows && c >= 0 && c < Columns;
    }

    public bool IsValidPosition(int r, int c)
    {
        return IsInsideGrid(r, c) && (_grid[r,c] == '0' || _grid[r, c] == 'B');
    }

    public bool IsBlackTile(int r, int c)
    {
        return _grid[r, c] == 'B';
    }

    private void SetRandomGrid()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                _grid[r, c] = '0';
            }
        }
        
        Random random = new Random();
        int amountOfBlackTiles = 5;
        
        while (amountOfBlackTiles != 0)
        {
            SetRandomBlackTile(random);
            amountOfBlackTiles--;
        }
    }

    private void SetRandomBlackTile(Random random)
    {
        int randomRow = random.Next(0, Rows);
        int randomColumn = random.Next(0, Columns);

        if (_grid[randomRow, randomColumn] != 'B')
        {
            _grid[randomRow, randomColumn] = 'B';
        }
        else
            SetRandomBlackTile(random);
    }
    private int CountFilledCells()
    {
        int count = 0;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (_grid[i, j] != '0' && _grid[i, j] != 'B')
                    count++;
            }
        }

        return count;
    }
}