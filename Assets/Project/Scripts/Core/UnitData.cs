using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Object/Units/Unit Data")]
public class UnitData : ScriptableObject
{
    [Header("Basis")]
    public float moveSpeed = 1f;
    public float hp = 1f;
    public float attackSpeed = 1f;
    public float attackPower = 1f;
    public float defense = 1f;



    public UnitData(UnitData other)
    {
        if (other == null)
        {
            Debug.LogError("Cannot create UnitData from null reference");
            return;
        }

        moveSpeed = other.moveSpeed;
        hp = other.hp;
        attackSpeed = other.attackSpeed;
        attackPower = other.attackPower;
        defense = other.defense;
    }
}