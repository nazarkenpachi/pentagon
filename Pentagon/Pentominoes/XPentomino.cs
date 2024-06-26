﻿namespace Pentagon.Pentominoes;

public class XPentomino : Pentomino
{
    private readonly Position[][] tiles = new Position[][]
    {
        new Position[]
        {
            new(0,1),
            new(1,0),
            new(1,1),
            new(1,2),
            new(2,1)
        }
    };
    public override char ID => 'X';
    
    protected override Position[][] Tiles => tiles;
}