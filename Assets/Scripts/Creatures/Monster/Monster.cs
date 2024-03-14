using UnityEngine;


public class Monster : Creature
{
    [Tooltip("몬스터 스텟")]
    [SerializeField] private MonsterData data;

    public MonsterData Data => data;
}
