using UnityEngine;

public class Weapon : MonoBehaviour
{
    // 플레이어가 무기를 장착했을 때, 사용하는 손잡이 부분 위치
    [SerializeField] public Transform socket;

    // 무기 아트
    [SerializeField] public SpriteRenderer body;

    // 무기 스텟 정보
    [SerializeField] public WeaponData data;
}