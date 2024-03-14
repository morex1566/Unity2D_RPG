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

    private void OnFire(InputValue inputValue)
    {
    
    }
}
