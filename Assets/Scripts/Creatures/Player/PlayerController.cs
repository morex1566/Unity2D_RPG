using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement  movement;
    private PlayerAnimation anim;

    private void Awake()
    {
        Player player = GetComponent<Player>();
        {
            movement = player.Movement;
            anim = player.Anim;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movement.InputDirection = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// Press & Release 입력을 받아서 캐스팅합니다.    <br/>
    /// Press : 캐스팅을 시작합니다.                  <br/>
    /// Release : 캐스팅을 종료합니다.                <br/>
    /// </summary>
    private void OnCast(InputValue inputValue)
    {
        movement.Cast();
    }
}
