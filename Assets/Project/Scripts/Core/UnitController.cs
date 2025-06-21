using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitController : MonoBehaviour, IObjectSelectable, ICommandable
{
    public Queue<Action> commands { get; set; } = new();



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
}
