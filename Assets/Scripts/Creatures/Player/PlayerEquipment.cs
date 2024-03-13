using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerEquipment : MonoBehaviour
{
    // 플레이어가 장비하는 무기 인스턴스
    [SerializeField] private GameObject weapon;

    // 플레이어의 장비한 무기의 위치
    [SerializeField] private Transform weaponSocket;

    private void Awake()
    {
        if (weapon)
        {
            weapon = Instantiate(weapon);
            EquipWeapon(weapon);
        }
    }

    /// <summary>
    /// 무기를 손에 장비합니다.
    /// </summary>
    /// <param name="weaponInstance"></param>
    public void EquipWeapon(GameObject weaponInstance)
    {
        // 인스턴스가 무기인지 확인합니다.
        Weapon weaponComp = weaponInstance.GetComponent<Weapon>();
        if (!weaponComp)
        {
            Debug.LogError($"{nameof(PlayerEquipment)}.cs : {weaponInstance}는 무기가 아닙니다.");
            return;
        }

        // 손에 무기를 장비합니다.
        weapon = weaponInstance;
        Transform weaponTransform = weapon.transform;
        {
            weaponTransform.SetParent(weaponSocket);
            weaponTransform.Translate(weaponSocket.transform.position, Space.Self);
        }
    }
}
