using MBT;
using UnityEngine;

[AddComponentMenu("")]
public class UnitControllerVariable : Variable<UnitController>
{
    protected override bool ValueEquals(UnitController val1, UnitController val2)
    {
        throw new System.NotImplementedException();
    }
}

[System.Serializable]
public class UnitControllerReference : VariableReference<UnitControllerVariable, UnitController>
{
    public UnitControllerReference(VarRefMode mode = VarRefMode.EnableConstant)
    {
        SetMode(mode);
    }

    protected override bool isConstantValid
    {
        get { return constantValue != null; }
    }

    public UnitController Value
    {
        get
        {
            return (useConstant) ? constantValue : this.GetVariable().Value;
        }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                this.GetVariable().Value = value;
            }
        }
    }
}
