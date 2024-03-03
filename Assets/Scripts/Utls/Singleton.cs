using UnityEngine;

/// <summary>
/// 싱글톤 클래스를 생성, DontDestroyOnLoad에 인스턴스 로드
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 싱글톤 인스턴스 생성 및 반환
    /// </summary>
    public static T GetInstance()
    {
        if (instance == null)
        {
            GameObject singletonInstance = new GameObject();
            singletonInstance.name = typeof(T).Name;
            singletonInstance.AddComponent<T>();
        }

        return instance;
    }

    public static T Instance => instance;
}