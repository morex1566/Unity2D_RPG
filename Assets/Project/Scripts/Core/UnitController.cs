using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour, IObjectSelectable, ICommandable
{
    public Queue<Action<object>> commands { get; set; } = new();



    public void OnSelect()
    {
        Debug.Log("selected");
    }

    public void OnDeselect()
    {
        Debug.Log("unselected");
    }
}
