using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelector : MonoBehaviour
{
    [field: SerializeField] public LayerMask selectableLayer { get; set; }

    [field: SerializeField] public GameObject selectionBoxPb { get; set; }

    [field: SerializeField] public Canvas canvas { get; set; }



    public bool isDragging { get; private set; } = false;

    public Vector3 startMousePos { get; private set; } = Vector3.zero;

    public Vector3 currMousePos { get; private set; } = Vector3.zero;

    public List<GameObject> selectedUnits { get; private set; } = new();

    public GameObject selectionBoxObj { get; private set; } = null;

    public RectTransform selectionBoxRect { get; private set; } = null;



    private void Awake()
    {
        GameManager.inputMappingContext.Player.Click.performed += OnStartDragging;
        GameManager.inputMappingContext.Player.Click.canceled += OnStopDragging;
    }

    private void Start()
    {
        selectionBoxObj = Instantiate(selectionBoxPb, Vector3.zero, Quaternion.identity, canvas.transform);
        selectionBoxRect = selectionBoxObj.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isDragging)
        {
            UpdateSelectionBox();
        }
    }

    private void OnDestroy()
    {
        GameManager.inputMappingContext.UI.Click.performed -= OnStartDragging;
        GameManager.inputMappingContext.UI.Click.canceled -= OnStopDragging;
    }



    public void OnStartDragging(InputAction.CallbackContext context)
    {
        OnBeforeDraggingStart();

        startMousePos = UIf.GetMouseWorldPosition();
        selectionBoxObj.SetActive(true);
        isDragging = true;
    }

    public void OnStopDragging(InputAction.CallbackContext context)
    {
        currMousePos = UIf.GetMouseWorldPosition();
        selectionBoxObj.SetActive(false);
        isDragging = false;

        // 1. 드래그 박스가 적당하다면 다중 선택 로직
        // 2. 드래그 박스가 너무 작다면 단일 선택 로직
        if (IsSelectionBoxUsable())
        {
            SelectUnits();
        }
        else
        {
            SelectUnit();
        }

        OnAfterDraggingEnd();
    }



    private bool IsSelectionBoxUsable()
    {
        return selectionBoxRect.sizeDelta.x > 4f && selectionBoxRect.sizeDelta.y > 4f;
    }

    private void SelectUnits()
    {
        // 드래그 영역을 월드 좌표로 변환
        Vector2 min = new Vector2(
            Mathf.Min(startMousePos.x, currMousePos.x),
            Mathf.Min(startMousePos.y, currMousePos.y)
        );
        Vector2 max = new Vector2(
            Mathf.Max(startMousePos.x, currMousePos.x),
            Mathf.Max(startMousePos.y, currMousePos.y)
        );

        // 영역 내 유닛 감지
        Collider2D[] colliders = Physics2D.OverlapAreaAll(min, max, selectableLayer);
        foreach (var collider in colliders)
        {
            GameObject unit = collider.gameObject;

            // 선택 시, 효과 
            var selectables = unit.GetComponents<IObjectSelectable>();
            foreach (var selectable in selectables)
            {
                selectable.OnSelect();
            }

            selectedUnits.Add(unit);
        }
    }

    private void SelectUnit()
    {
        Collider2D collider = Physics2D.OverlapPoint(currMousePos, selectableLayer);
        if (collider != null)
        {
            GameObject unit = collider.gameObject;
            selectedUnits.Add(unit);
            unit.GetComponent<IObjectSelectable>().OnSelect();
        }
    }

    private void UpdateSelectionBox()
    {
        currMousePos = UIf.GetMouseWorldPosition();

        Vector2 upperLeftWorldPos = new Vector2(Mathf.Min(startMousePos.x, currMousePos.x), Mathf.Max(startMousePos.y, currMousePos.y));
        Vector2 lowerRightWorldPos = new Vector2(Mathf.Max(startMousePos.x, currMousePos.x), Mathf.Min(startMousePos.y, currMousePos.y));

        Vector2 upperLeftScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, upperLeftWorldPos);
        Vector2 lowerRightScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, lowerRightWorldPos);

        selectionBoxRect.position = (upperLeftScreenPos + lowerRightScreenPos) / 2;
        selectionBoxRect.sizeDelta = new Vector2(Mathf.Abs(upperLeftScreenPos.x - lowerRightScreenPos.x), Mathf.Abs(upperLeftScreenPos.y - lowerRightScreenPos.y));
    }

    private void OnBeforeDraggingStart()
    {
        foreach (var unit in selectedUnits)
        {
            // 선택해제 시, 효과
            var selectables = unit.GetComponents<IObjectSelectable>();
            foreach (var selectable in selectables)
            {
                selectable.OnDeselect();
            }
        }

        selectedUnits.Clear();
    }

    private void OnAfterDraggingEnd()
    {
        selectionBoxRect.sizeDelta = Vector2.zero;
    }
}