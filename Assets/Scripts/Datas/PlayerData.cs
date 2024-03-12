using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/Player Data")]
[Serializable]
public class PlayerData : ScriptableObject
{
    [Header("플레이어 기본 스텟")]
    public float speed;
    public float hp;
    public float sp;
}
