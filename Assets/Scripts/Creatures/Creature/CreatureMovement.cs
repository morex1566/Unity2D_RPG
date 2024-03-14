using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 크리쳐의 움직임을 관리하는 최상위 클래스
/// </summary>
public abstract partial class CreatureMovement : MonoBehaviour
{
    // 크리쳐가 현재 바라보고 있는 방향
    protected Vector2 lookAtDirection       = Vector2.zero;

    // 크리쳐가 현재 움직이고 있는 방향
    protected Vector2 currentMoveDirection  = Vector2.zero;

    protected abstract void Move();
}

/// <summary>
/// 프로퍼티 선언
/// </summary>
public abstract partial class CreatureMovement
{
    // 크리쳐가 현재 바라보고 있는 방향
    public Vector2 LookAtDirection => lookAtDirection;

    // 크리쳐가 현재 움직이고 있는 방향
    public Vector2 CurrentMoveDirection => currentMoveDirection;
}