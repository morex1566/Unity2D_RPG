
using System;

[Flags]
public enum PlayerMovementState
{
    Idle = 0,
    Move = 1,
}

[Flags]
public enum PlayerActionState
{
    Idle = 0,
    Fire = 1,
    Cast = 2,
}
