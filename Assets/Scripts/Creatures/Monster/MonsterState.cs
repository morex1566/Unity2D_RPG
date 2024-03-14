using System;

[Flags]
public enum MonsterMovementState
{
    Idle = 0,
    Move = 1,
    Die = 2,
}

[Flags]
public enum MonsterActionState
{
    Idle = 0,
    Chase = 1,
    Attack = 2,
    Wander = 4,
    Patrol = 8,
}