using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathfindingGrid
{
    public PathfindingCellPerTile cellPerTile { get; private set; }

    public PathfindingCell[,] cells { get; private set; }

    public Grid grid { get; private set; }

    public GridLayout gridLayout { get; private set; }

    public Tilemap[] tilemaps { get; private set; }

    public Vector2 cellSize { get; private set; }

    public Vector2Int gridSize { get; private set; }

    public int gridXMax { get; private set; }

    public int gridYMax { get; private set; }

    public int gridXMin { get; private set; }

    public int gridYMin { get; private set; }



    public PathfindingGrid(Tilemap[] tilemaps, Grid grid, GridLayout gridLayout, PathfindingCellPerTile cellPerTile)
    {
        this.cellPerTile = cellPerTile;
        this.tilemaps = tilemaps;
        this.grid = grid;
        this.gridLayout = gridLayout;

        InitGridParams();
        InitCells();
    }



    private void InitGridParams()
    {
        gridXMin = int.MaxValue;
        gridXMax = int.MinValue;
        gridYMin = int.MaxValue;
        gridYMax = int.MinValue;

        foreach (var tilemap in tilemaps)
        {
            BoundsInt bounds = tilemap.cellBounds;
            gridXMin = Math.Min(gridXMin, bounds.xMin);
            gridXMax = Math.Max(gridXMax, bounds.xMax);
            gridYMin = Math.Min(gridYMin, bounds.yMin);
            gridYMax = Math.Max(gridYMax, bounds.yMax);
        }

        gridSize = new Vector2Int(gridXMax - gridXMin, gridYMax - gridYMin) * (int)cellPerTile;
        cellSize = grid.cellSize / (int)cellPerTile;
    }

    private void InitCells()
    {
        cells = new PathfindingCell[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                InitCell(tilemaps, x, y);
            }
        }
    }

    private void InitCell(Tilemap[] tilemaps, int x, int y)
    {
        Vector2 worldPos = new Vector2(gridXMin + cellSize.x / 2 + cellSize.x * x, gridYMin + cellSize.y / 2 + cellSize.y * y);
        Vector2Int index = new Vector2Int(x, y);
        PathfindingCellType type = PathfindingCellType.Tile_None;

        for (int i = 0; i < tilemaps.Length; i++)
        {
            Vector3Int cellPos = tilemaps[i].WorldToCell(worldPos);
            if (tilemaps[i].HasTile(cellPos))
            {
                type |= Enum.Parse<PathfindingCellType>(LayerMask.LayerToName(tilemaps[i].gameObject.layer));
            }
        }

        cells[x, y] = new PathfindingCell(worldPos, index, type);
    }
}
