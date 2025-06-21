using UnityEngine;

public class PathfindingCell
{
    public Vector2 worldPos { get; set; }
    public Vector2Int index { get; set; }
    public PathfindingCellType type { get; set; }

    public PathfindingCell(Vector2 worldPos, Vector2Int index, PathfindingCellType type)
    {
        this.worldPos = worldPos;
        this.index = index;
        this.type = type;
    }

    // 복사 생성자
    public PathfindingCell(PathfindingCell other)
    {
        worldPos = other.worldPos;
        index = other.index;
        type = other.type;
    }
}
