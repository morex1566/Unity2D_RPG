using UnityEngine;

public static class UIf
{
    public static Vector2 ScreenToLocal(Canvas canvas, Vector2 screenPos)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPos,
            GetCanvasCamera(canvas),
            out Vector2 localPos);
        return localPos;
    }

    public static Vector2 WorldToLocal(Canvas canvas, Vector3 worldPos, Camera camera = null)
    {
        Camera cam = camera ?? Camera.main;
        if (cam == null)
        {
            Debug.LogError("No camera provided and Camera.main is null!");
            return Vector2.zero;
        }

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(cam, worldPos);
        return ScreenToLocal(canvas, screenPos);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;

        return worldPosition;
    }

    private static Camera GetCanvasCamera(Canvas canvas)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            return null;

        return canvas.worldCamera ?? Camera.main;
    }
}