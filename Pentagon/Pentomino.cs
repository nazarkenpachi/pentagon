using System.Collections.Generic;

namespace Pentagon;

public abstract class Pentomino
{
    protected abstract Position[][] Tiles { get; }
    
    public abstract char ID { get; }

    private Position position;
    private int rotationState;
    
    public bool IsPlaced { get; set; }

    public Pentomino()
    {
        position = new Position(0, 0);
    }
    
    public IEnumerable<Position> TilePosition()
    {
        foreach (Position p in Tiles[rotationState])
        {
            yield return new Position(p.Row + position.Row, p.Column + position.Column);
        }
    }

    public void RotateTile()
    {
        rotationState = (rotationState + 1) % Tiles.Length;
    }
}