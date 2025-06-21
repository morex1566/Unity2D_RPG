using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Unit/Move Toward")]
public class MoveToward : UnitLeaf
{
    public override NodeResult Execute()
    {
        return NodeResult.running;
    }
}
