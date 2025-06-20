using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandable
{
    public Queue<Action<object>> commands { get; set; }
}
