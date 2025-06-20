using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static GameObject _singletonObj = null;

    private static T _instance;

    private static readonly object _locker = new object();

    private static bool _applicationIsQuitting = false;

    public static T instance
    {
        get => _instance ?? GetInstance();
        private set => _instance = value;
    }



    private static T GetInstance()
    {
        if (_applicationIsQuitting)
        {
            return null;
        }

        lock (_locker)
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    _singletonObj = new GameObject();
                    _instance = _singletonObj.AddComponent<T>();
                    _singletonObj.name = typeof(T).Name + " (Singleton)";

                    DontDestroyOnLoad(_singletonObj);
                }
            }
            return _instance;
        }
    }



    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _applicationIsQuitting = true;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _applicationIsQuitting = true;
    }
}