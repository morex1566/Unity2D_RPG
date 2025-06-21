using MBT;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode(name = "Unit/Detect Enemy Service")]
public class DetectEnemyService : UnitService
{
    [field: SerializeField] public LayerMask mask { get; private set; }

    [field: SerializeField] public float range { get; private set; } = 15;



    public override void Task()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, mask, QueryTriggerInteraction.Ignore);
        if (colliders.Length > 0)
        {
            Debug.Log("detected");
        }
        else
        {
            Debug.Log("undetected");
        }
    }
}
