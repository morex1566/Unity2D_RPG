using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitController : MonoBehaviour, IObjectSelect, ICommandable
{
    public Queue<ICommand> commands { get; set; } = new();



    public void OnSelect()
    {
        Debug.Log("selected");
    }

    public void OnDeselect()
    {
        Debug.Log("unselected");
    }

    public void MoveTo(Vector2 destination)
    {

    }

    public void AttackTarget(GameObject target)
    {

    }

    public void HoldPosition()
    {

    }
}
