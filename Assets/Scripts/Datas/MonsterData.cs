using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Monster Data")]
[Serializable]
public class MonsterData : CreatureData
{
    [Header("몬스터 AI 정보")]
    [SerializeField] public float perceptionRange;
}
