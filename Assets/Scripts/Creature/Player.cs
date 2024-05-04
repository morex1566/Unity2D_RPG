using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Creature
{
    public PlayerData Status => status;
    private PlayerData status = null;

    public PlayerState State => state;
    private PlayerState state = PlayerState.Movement_None;

    private Vector3 nextMoveDirection = Vector3.zero;

    private Vector3 nextVelocity = Vector3.zero;

    private Coroutine casting = null;

    private Coroutine moving = null;


    private void Start()
    {
        status = Instantiate(base.data as PlayerData);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        nextVelocity = nextMoveDirection * status.MoveSeed;
        rigid.velocity = nextVelocity;
    }

    private IEnumerator MoveImpl()
    {
        while (true)
        {
            yield return null;
        }

        moving = null;
    }

    public void Cast()
    {

    }

    private IEnumerator CastImpl()
    {
        while (true)
        {
            yield return null;
        }

        casting = null;
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetMoving(InputValue inputValue)
    {
        nextMoveDirection = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetCasting(InputValue inputValue)
    {
        state &= PlayerState.Action_None;
        state |= PlayerState.Action_Cast;
    }

    /// <summary>
    /// 
    /// </summary>
    private void AnimateMoving()
    {
        float nextMoveDistance = nextMoveDirection.magnitude;
        if (nextMoveDistance > 0f)
        {
            animator.SetBool(nameof(PlayerState.Movement_Run), true);
            animator.SetBool(nameof(PlayerState.Movement_None), false);
        }
        else
        {
            animator.SetBool(nameof(PlayerState.Movement_Run), false);
            animator.SetBool(nameof(PlayerState.Movement_None), true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void AnimateCasting()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void OnInputMove(InputValue inputValue)
    {
        SetMoving(inputValue);
        AnimateMoving();
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnInputCast(InputValue inputValue)
    {
        SetCasting(inputValue);
        AnimateCasting();
        Cast();
    }
}