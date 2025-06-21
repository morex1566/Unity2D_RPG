using UnityEngine;

[RequireComponent(typeof(PathfindingGridController))]
public class PathfindingGridDebugger : MonoBehaviour
{
    [field: SerializeField] public Color gizmosColor { get; private set; } = Color.yellow;

    public PathfindingGridController pathfindingGridController { get; private set; }



    private void Awake()
    {
        pathfindingGridController = GetComponent<PathfindingGridController>();
    }

    private void OnDrawGizmos()
    {
        // 런타임이 아닌 경우, 그리기 중단
        if (!Application.isPlaying)
        {
            return;
        }

        var grid = pathfindingGridController.pathfindingGrid;

        Gizmos.color = gizmosColor;      

        Vector2 cellSize = grid.cellSize;
        for (int x = 0; x < grid.gridSize.x; x++)
        {
            for (int y = 0; y < grid.gridSize.y; y++)
            {
                Vector2 worldPos = new Vector2(
                    grid.gridXMin + cellSize.x / 2 + cellSize.x * x,
                    grid.gridYMin + cellSize.y / 2 + cellSize.y * y
                );

                Gizmos.DrawWireCube(worldPos, new Vector3(cellSize.x, cellSize.y, 0f));
            }
        }
    }
}