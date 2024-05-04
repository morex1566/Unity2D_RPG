using System;

[Flags]
public enum PlayerState
{
    Movement_None = 1 << 0,
    Movement_Run = 1 << 2,

    Action_None = 1 << 3,
    Action_Cast = 1 << 4,
}
