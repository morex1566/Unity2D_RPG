using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface ICommandable
{
    public Queue<ICommand> commands { get; set; }
}

public interface ICommand
{
    public void Execute();
}