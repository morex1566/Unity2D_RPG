using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected CreatureData data;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Rigidbody2D rigid;

    [SerializeField] protected Collider2D hitbox;

    [SerializeField] protected SpriteRenderer spriter;
}