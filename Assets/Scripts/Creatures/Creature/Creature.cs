using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] protected Animator         animator;
    [SerializeField] protected SpriteRenderer   body;
    [SerializeField] protected Rigidbody2D      rigid;

    public Animator Animator => animator;
    public SpriteRenderer Body => body;
    public Rigidbody2D Rigid => rigid;
}
