using MBT;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Unit/Wait Command")]
public class WaitForCommand : UnitLeaf
{
    public override NodeResult Execute()
    {
        return commandable.commands.Count <= 0 ? NodeResult.running : NodeResult.success;
    }
}
