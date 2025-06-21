using System;
using System.ComponentModel;
using UnityEngine;

[Flags]
public enum PathfindingCellType
{
    [Description(nameof(Default))]
    Default = 0,

    [Description(nameof(Tile_None))]
    Tile_None = 0,

    [Description(nameof(Tile_Ground))]
    Tile_Ground = 1 << 1,

    [Description(nameof(Tile_Wall))]
    Tile_Wall = 1 << 2,
}

public enum PathfindingCellPerTile
{
    One = 1,
    Two = 2,
    Four = 4
}