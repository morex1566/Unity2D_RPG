using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class PathfindingGridController : MonoBehaviour
{
    [field: SerializeField] public PathfindingCellPerTile cellPerTile { get; private set; } = PathfindingCellPerTile.Two;

    public PathfindingGrid pathfindingGrid { get; private set; }


    private void Awake()
    {
        var grid = GetComponent<Grid>();
        var gridLayout = GetComponent<GridLayout>();
        var tilemaps = GetComponentsInChildren<Tilemap>();

        pathfindingGrid = new PathfindingGrid(tilemaps, grid, gridLayout, cellPerTile);
    }
}
