namespace Pentagon;

public class GameProcess
{
    public Grid Board { get; }
    
    public Pentomino SelectedPentomino { get; }
    
    public GameProcess()
    {
        Board = new Grid(12, 12);
        Board.SetRandomGrid();
    }

    private bool BlockFits()
    {
        foreach (Position p in SelectedPentomino.TilePosition())
        {
            if (!Board.IsEmpty(p.Row, p.Column) || Board.IsBlackTile(p.Row, p.Column))
                return false;
        }
        return true;
    }

    public void RotatePentomino()
    {
        SelectedPentomino.RotateTile();
    }

    public void PlacePentomino()
    {
        foreach (var p in SelectedPentomino.TilePosition())
        {
            Board[p.Row, p.Column] = SelectedPentomino.ID;
        }

        SelectedPentomino.IsPlaced = true;
        if (IsGameOver())
        {
            
        }
    }

    public bool IsGameOver()
    {
        return true;
    }
}