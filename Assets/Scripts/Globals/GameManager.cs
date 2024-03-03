using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// 첫 씬이 로드되고, Hierarchy에 있는 GameObject들 Awake()가 호출되기 전에 실행
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeFirstSceneLoad()
    {
        Init();
    }

    /// <summary>
    /// 첫 씬이 로드될 때, 초기화할 것들은 여기에
    /// </summary>
    private static void Init()
    {
        GetInstance();   
    }
}
