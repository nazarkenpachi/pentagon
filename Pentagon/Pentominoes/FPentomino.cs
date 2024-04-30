namespace Pentagon.Pentominoes;

public class FPentomino : Pentomino
{
    private readonly Position[][] tiles = new Position[][]
    {
        new Position[]
        {
            new(0, 1),
            new(0, 2),
            new(1, 0),
            new(1, 1),
            new(2, 1),
        },
        new Position[]
        {
            new(0, 1),
            new(1, 0),
            new(1, 1),
            new(1, 2),
            new(2, 2)
        },
        new Position[]
        {
            new(0, 1),
            new(1, 1),
            new(1, 2),
            new(2, 0),
            new(2, 1)
        },
        new Position[]
        {
            new(0, 0),
            new(1, 0),
            new(1, 1),
            new(1, 2),
            new(2, 1)
        }
    };

    public override char ID => 'F';

    protected override Position[][] Tiles => tiles;
}