using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Weapon Data")]
[Serializable]
public class WeaponData : ScriptableObject
{
    [Header("무기 기본 스텟")]
    [SerializeField] public float damage;
}
