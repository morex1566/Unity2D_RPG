using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    // Player로부터 받아야할 클래스들
    private PlayerData data = null;
    private Animator animator = null;
    private SpriteRenderer body = null;

    private PlayerMovementState movementState   = PlayerMovementState.Idle;
    private PlayerActionState actionState       = PlayerActionState.Idle;
    private Vector2 inputDir = Vector2.zero;
    private Vector2 lookAtDir = Vector2.zero;

    private void Awake()
    {
        Player player = GetComponent<Player>();
        {
            data = player.Data;
            animator = player.Animator;
            body = player.Body;
        }

        // 플레이어의 AttackBehaviour State에 컨트롤러를 전달
        List<AttackBehaviour> attackBehaviours 
            = animator.GetBehaviours<AttackBehaviour>().ToList();
        attackBehaviours.ForEach(attackBehaviour => attackBehaviour.Controller = this);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Animate();
    }

    private void OnMove(InputValue inputValue)
    {
        inputDir = inputValue.Get<Vector2>();
        if (inputDir.magnitude > 0f)
        {
            movementState = PlayerMovementState.Move;
        }
        else
        {
            movementState = PlayerMovementState.Idle;
        }
    }

    private void OnFire(InputValue inputValue)
    {
        actionState = PlayerActionState.Attack;
    }

    public void OnFireExit()
    {
        actionState = PlayerActionState.Idle;
    }

    private void Move()
    {
        Vector3 moveDir = inputDir * data.speed * Time.fixedDeltaTime;   
        transform.position += moveDir;
    }

    private void Animate()
    {
        if (inputDir.magnitude > 0f)
        {
            body.flipX = inputDir.x < 0f ? true : false;
        }

        switch (movementState)
        {
            case PlayerMovementState.Idle:
                animator.SetBool("Move", false);
                animator.SetBool("Idle", true);
                break;

            case PlayerMovementState.Move:
                animator.SetBool("Idle", false);
                animator.SetBool("Move", true);
                break;

            default:
                break;
        }

        switch (actionState)
        {
            case PlayerActionState.Idle:

                break;
            case PlayerActionState.Attack:
                animator.SetTrigger("Attack");

                break;
            default:

                break;
        }
    }
}
