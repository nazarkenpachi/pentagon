using System;

namespace Pentagon;

public class Grid : Board
{
    public Grid (int rows, int columns) : base(rows, columns)
    {
        
    }
    public bool IsInsideGrid(int r, int c)
    {
        return r >= 0 && r <= Rows && c >= 0 && c <= Rows;
    }

    public bool IsEmpty(int r, int c)
    {
        return IsInsideGrid(r, c) && _grid[r,c] == '0';
    }

    public bool IsBlackTile(int r, int c)
    {
        return _grid[r, c] == 'B';
    }

    public void SetRandomGrid()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                _grid[r, c] = '0';
            }
        }
        /*Random random = new Random();
        int amountOfBlackTiles = random.Next(5, 21);
        
        while (amountOfBlackTiles != 0)
        {
            SetRandomBlackTile(random);
            amountOfBlackTiles--;
        }*/
    }

    public void SetRandomBlackTile(Random random)
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
    
    /*public bool CanBeSolved()
    {
        
    }*/
}