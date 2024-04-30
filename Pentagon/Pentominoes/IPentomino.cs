namespace Pentagon.Pentominoes;

public class IPentomino : Pentomino
{
    private readonly Position[][] tiles = new Position[][]
    {
        new Position[]
        {
            new(0,0),
            new(1,0),
            new(2,0),
            new(3,0),
            new(4,0)
        },
        new Position[]
        {
            new(0,0),
            new(0,1),
            new(0,2),
            new(0,3),
            new(0,4)
        }
    };
    public override char ID => 'I';
    
    protected override Position[][] Tiles => tiles;
}