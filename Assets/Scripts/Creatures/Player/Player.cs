using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerController))]
public partial class Player : Creature
{
    // 기본 스텟 정보
    [SerializeField] private PlayerData data;

    // 애니메이션 관리자
    [SerializeField] private PlayerAnimation anim;

    // 이동 / 액션 관리자 
    [SerializeField] private PlayerMovement movement;

    // 현재 상태 정보
    private PlayerData status;

    private void Awake()
    {
        status = Instantiate(data);
    }
}
    
public partial class Player
{
    public PlayerData Data => data;
    public PlayerAnimation Anim => anim;
    public PlayerMovement Movement => movement;
    public PlayerData Status => status;
}