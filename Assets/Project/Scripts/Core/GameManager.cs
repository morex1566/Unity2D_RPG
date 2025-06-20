using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static InputMappingContext inputMappingContext;




    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeSceneLoad()
    {
        GameManager gm = instance;

        inputMappingContext = new InputMappingContext();
        inputMappingContext.Enable();
    }
}