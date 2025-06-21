using MBT;
using UnityEngine;

public class UnitService : Service
{
    [field: SerializeField] public UnitControllerReference unitController { get; private set; }

    public ICommandable commandable { get; private set; }



    private void Awake()
    {
        commandable = unitController.Value.GetComponent<ICommandable>();
    }

    public override void Task() { }
}
