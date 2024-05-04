using UnityEngine;

/// <summary>
/// <see cref="target"/>을 쫒아가는 탑-뷰 시점의 카메라.
/// </summary>
[RequireComponent(typeof(Camera))]
public class TopViewCamera : MonoBehaviour
{
    /// <summary>
    /// 카메라 설정
    /// </summary>
    [SerializeField] private TopViewCameraData data;

    /// <summary>
    /// 카메라가 쫒아갈 대상
    /// </summary>
    [SerializeField] private Transform target;



    private TopViewCameraData setting;



    private void Awake()
    {
        setting = Instantiate(data);
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// '<see cref="target"/>'을 중심으로 하도록 카메라를 이동합니다.
    /// </summary>
    private void Move()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, setting.depth);
        transform.position = targetPosition;
    }
}
