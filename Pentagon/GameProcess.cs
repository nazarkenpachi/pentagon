using System;
using System.Collections.Generic;
using System.Linq;
using Pentagon.Pentominoes;

namespace Pentagon;

public class GameProcess
{
    public Board Board { get; set; }
    
    public Pentomino SelectedPentomino { get; set; }
    
    public bool GameOver { get; set; }
    
    private static readonly int[] dRow = new int[] { -1, 1, 0, 0, -1, -1, 1, 1 };
    private static readonly int[] dCol = new int[] { 0, 0, -1, 1, -1, 1, -1, 1 };
    
    public GameProcess()
    {
        GameOver = false;
        Board = new Board(12, 12);
    }

    public bool BlockFits(int row, int column, Pentomino pentomino)
    {
        SelectedPentomino = pentomino;
        
        foreach (var p in SelectedPentomino.TilePosition())
        {
            if (!Board.IsValidPosition(p.Row + row, p.Column + column) || Board.IsBlackTile(p.Row + row, p.Column + column) || !Board.IsInsideGrid(p.Row + row, p.Column + column))
            {
                return false;
            }
            
            if (!IsPositionAndSurroundingsEmpty(p.Row + row, p.Column + column))
            {
                return false;
            }
        }
        
        return true;
    }

    private bool IsPositionAndSurroundingsEmpty(int row, int column)
    {
        if (!Board.IsValidPosition(row, column) || Board.IsBlackTile(row, column))
        {
            return false;
        }
        
        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dRow[i];
            int newCol = column + dCol[i];

            if (Board.IsInsideGrid(newRow, newCol) && !Board.IsValidPosition(newRow, newCol))
            {
                return false;
            }
        }

        return true;
    }

    public int RotatePentomino()
    {
        SelectedPentomino.RotateTile();
        return SelectedPentomino.RotationState;
    }

    public void PlacePentomino(int row, int column, Pentomino pentomino)
    {
        SelectedPentomino = pentomino;
        if (BlockFits(row, column, pentomino))
        {
            foreach (var p in SelectedPentomino.TilePosition())
            {
                Board[row + p.Row, column + p.Column] = SelectedPentomino.ID;
            }
            SelectedPentomino.IsPlaced = true;
        }
    }

    public void RemovePentomino(int row, int column, Pentomino pentomino)
    {
        SelectedPentomino = pentomino;
        foreach (var p in pentomino.TilePosition())
        {
            int newRow = row + p.Row;
            int newCol = column + p.Column;

            if (Board.IsInsideGrid(newRow, newCol))
            {
                Board[newRow, newCol] = '0';
            }
        }
        pentomino.IsPlaced = false;
    }

    public List<Position> ReturnHighlightedTiles(int row, int column)
    {
        if (BlockFits(row, column, SelectedPentomino))
            return SelectedPentomino.TilePosition().Select(p => new Position(p.Row + row, p.Column + column)).ToList();
        return new List<Position>();
    }

    public void CreateNewBoard()
    {
        GameOver = false;
        Board.SetRandomGrid();
    }
}