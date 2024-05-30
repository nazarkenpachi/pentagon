using System.Collections.Generic;

namespace Pentagon;

public abstract class Pentomino
{
    public abstract Position[][] Tiles { get; }
    
    public abstract char ID { get; }

    private Position _positionOnBoard;
    public int RotationState { get; set; }
    
    public bool IsPlaced { get; set; }
    
    public Pentomino(int startingRotationState = 0)
    {
        _positionOnBoard = new Position(0, 0);
        RotationState = startingRotationState;
    }
    
    public IEnumerable<Position> TilePosition()
    {
        foreach (Position p in Tiles[RotationState])
        {
            yield return new Position (p.Row + _positionOnBoard.Row, p.Column + _positionOnBoard.Column);
        }
    }
    
    public override bool Equals(object obj)
    {
        if (obj is Pentomino other)
        {
            return this.GetType() == other.GetType();
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.GetType().GetHashCode();
    }

    public void RotateTile()
    {
        RotationState = (RotationState + 1) % Tiles.Length;
    }
}