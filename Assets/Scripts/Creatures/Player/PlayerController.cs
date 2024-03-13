using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerEquipment))]
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

        // 플레이어의 FireBehaviour를 초기화
        List<FireBehaviour> fireBehaviours 
            = animator.GetBehaviours<FireBehaviour>().ToList();
        fireBehaviours.ForEach(fireBehaviour => 
        {
            fireBehaviour.Controller = this;
            fireBehaviour.OnStateExitAction += OnFireExit;
        });
    }



    private void FixedUpdate()
    {
        if ((movementState & PlayerMovementState.Move) != 0)
        {
            Move();
        }

        if ((actionState & PlayerActionState.Cast) != 0)
        {
            Cast();
        }
    }

    private void Move()
    {
        Vector3 moveDir = inputDir * data.speed * Time.fixedDeltaTime;
        transform.position += moveDir;
    }

    private void Cast()
    {

    }



    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (inputDir.x > 0f)
        {
            body.flipX = false;
        }
        if (inputDir.x < 0f)
        {
            body.flipX = true;
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
                animator.SetBool("Cast", false);
                break;

            case PlayerActionState.Cast:
                animator.SetBool("Cast", true);
                break;

            default:
                break;
        }
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
        actionState = PlayerActionState.Cast;
    }

    private void OnFireExit()
    {
        actionState = PlayerActionState.Idle;
    }
}
