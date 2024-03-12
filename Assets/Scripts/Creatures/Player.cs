using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator           animator;
    [SerializeField] private SpriteRenderer     body;
    [SerializeField] private Rigidbody2D        rigid;
    [SerializeField] private PlayerData         data;

    public Animator Animator => animator;
    public SpriteRenderer Body => body;
    public Rigidbody2D Rigid => rigid;
    public PlayerData Data => data;
}
    