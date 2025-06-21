using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Unit/Attack Enemy")]
public class AttackEnemy : Leaf
{
    public override NodeResult Execute()
    {
        return NodeResult.running;
    }
}
