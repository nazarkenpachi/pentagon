namespace Pentagon.Pentominoes;

public class ZPentomino : Pentomino
{
    private readonly Position[][] tiles = new Position[][]
    {
        new Position[]
        {
            new(0,0),
            new(0,1),
            new(1,1),
            new(2,1),
            new(2,2)
        },
        new Position[]
        {
            new(0,2),
            new(1,0),
            new(1,1),
            new(1,2),
            new(2,0)
        }
    };
    public override char ID => 'Z';
    
    public override Position[][] Tiles => tiles;
    public ZPentomino(int startingRotationState = 0) : base(startingRotationState)
    {
        
    }
}