namespace Pentagon.Pentominoes;

public class YPentomino : Pentomino
{
    private readonly Position[][] tiles = new Position[][]
    {
        new Position[]
        {
            new(0, 0),
            new(1, 0),
            new(2, 0),
            new(2, 1),
            new(3, 0)
        },
        new Position[]
        {
            new(0, 0),
            new(0, 1),
            new(0, 2),
            new(0, 3),
            new(1, 1)
        },
        new Position[]
        {
            new(0, 3),
            new(1, 2),
            new(1, 3),
            new(2, 3),
            new(3, 3)
        },
        new Position[]
        {
            new(2, 2),
            new(3, 0),
            new(3, 1),
            new(3, 2),
            new(3, 3)
        }
    };
    
    public override char ID => 'Y';
    
    protected override Position[][] Tiles => tiles;
}