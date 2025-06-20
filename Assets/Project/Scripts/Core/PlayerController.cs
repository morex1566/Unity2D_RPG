using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public ObjectSelector objectSelectorPb { get; private set; }

    public ObjectSelector objectSelectorObj { get; private set; }


    private void Awake()
    {
        GameManager.inputMappingContext.Player.Click.performed += OnMoveUnitsTo;
    }

    private void Start()
    {
        objectSelectorObj = Instantiate(objectSelectorPb, transform);
    }

    private void OnMoveUnitsTo(InputAction.CallbackContext context)
    {
        // 선택된 유닛이 없다면?
        List<GameObject> units = objectSelectorObj.selectedUnits;
        if (units.Count == 0)
        {
            return;
        }

        foreach (var unit in units)
        {

        }
    }
}
