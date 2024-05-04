using UnityEngine;

[CreateAssetMenu(fileName = "TopViewCamera_Data", menuName = "Scriptable Objects/TopViewCamera_Data")]
public class TopViewCameraData : ScriptableObject
{
    /// <summary>
    /// 카메라의 Z 좌표
    /// </summary>
    public float depth;
}
