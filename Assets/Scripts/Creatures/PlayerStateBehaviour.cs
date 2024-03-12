using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBehaviour : StateMachineBehaviour
{
    protected PlayerController controller;

    public PlayerController Controller
    {
        get
        {
            return controller;
        }
        set
        {
            controller = value;
        }
    }
}
