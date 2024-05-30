namespace Pentagon.Pentominoes;

public class NPentomino : Pentomino
{
    private readonly Position[][] tiles = new Position[][]
    {
        new Position[]
        {
            new(0,1),
            new(1,1),
            new(2,0),
            new(2,1),
            new(3,0)
        },
        new Position[]
        {
            new(0,0),
            new(0,1),
            new(1,1),
            new(1,2),
            new(1,3)
        },
        new Position[]
        {
            new(0,1),
            new(1,0),
            new(1,1),
            new(2,0),
            new(3,0)
        },
        new Position[]
        {
            new(0,0),
            new(0,1),
            new(0,2),
            new(1,2),
            new(1,3)
        }
    };

    public override char ID => 'N';

    public override Position[][] Tiles => tiles;
    public NPentomino(int startingRotationState = 0) : base(startingRotationState)
    {
        
    }
}
