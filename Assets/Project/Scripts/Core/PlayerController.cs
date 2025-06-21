using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public ObjectSelector objectSelectorPb { get; private set; }

    public ObjectSelector objectSelectorObj { get; private set; }


    private void Awake()
    {
        GameManager.inputMappingContext.Player.RightClick.performed += OnCommandMoveUnitsTo;
    }

    private void Start()
    {
        objectSelectorObj = Instantiate(objectSelectorPb, transform);
    }

    private void OnCommandMoveUnitsTo(InputAction.CallbackContext context)
    {
        List<UnitController> units = objectSelectorObj.selectedUnits.Select(selectedUnits => selectedUnits.GetComponent<UnitController>()).ToList();

        foreach (var unit in units)
        {
            Vector2 destination = UIf.GetMouseWorldPosition();
            unit.commands.Enqueue(() => unit.MoveTo(destination));
        }
    }

    private void OnCommandCharge(InputAction.CallbackContext context)
    {
        List<UnitController> units = objectSelectorObj.selectedUnits.Select(selectedUnits => selectedUnits.GetComponent<UnitController>()).ToList();

    }

    private void OnCommandHoldPosition(InputAction.CallbackContext context)
    {
        List<UnitController> units = objectSelectorObj.selectedUnits.Select(selectedUnits => selectedUnits.GetComponent<UnitController>()).ToList();

    }
}
