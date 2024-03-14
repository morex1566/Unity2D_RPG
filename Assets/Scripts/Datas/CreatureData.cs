using System;
using UnityEngine;


[Serializable]
public class CreatureData : ScriptableObject
{
    [Header("기본 스텟")]
    [SerializeField] public float speed;
    [SerializeField] public float hp;
    [SerializeField] public float sp;
}
