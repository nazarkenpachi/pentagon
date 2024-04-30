using System;

namespace Pentagon;

public class Grid
{
    private readonly char[,] grid;
    
    public int Rows { get; }
    
    public int Columns { get; }

    public char this[int r, int c]
    {
        get => grid[r, c];
        set => grid[r, c] = value;
    }

    public Grid (int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        grid = new char[rows, columns];
    }

    public bool IsInsideGrid(int r, int c)
    {
        return r >= 0 && r <= Rows && c >= 0 && c <= Rows;
    }

    public bool IsEmpty(int r, int c)
    {
        return IsInsideGrid(r, c) && grid[r,c] == '0';
    }

    public bool IsBlackTile(int r, int c)
    {
        return grid[r, c] == 'B';
    }

    public void SetRandomGrid()
    {
        Random random = new Random();
        int amountOfBlackTiles = random.Next(5, 21);
        
        while (amountOfBlackTiles != 0)
        {
            SetRandomBlackTile(random);
            amountOfBlackTiles--;
        }
    }

    public void SetRandomBlackTile(Random random)
    {
        int randomRow = random.Next(0, Rows);
        int randomColumn = random.Next(0, Columns);

        if (grid[randomRow, randomColumn] != 'B')
        {
            grid[randomRow, randomColumn] = 'B';
        }
        else
            SetRandomBlackTile(random);
    }
    
    /*public bool CanBeSolved()
    {
        
    }*/
}