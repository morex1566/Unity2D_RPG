using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelector : MonoBehaviour
{
    [field: SerializeField] public LayerMask selectableLayer { get; set; }

    [field: SerializeField] public GameObject selectionBoxPb { get; set; }

    public Canvas canvas { get; private set; } = null;

    public bool isDragging { get; private set; } = false;

    public Vector3 startMousePos { get; private set; } = Vector3.zero;

    public Vector3 currMousePos { get; private set; } = Vector3.zero;

    public List<GameObject> selectedUnits { get; private set; } = new();

    public GameObject selectionBoxObj { get; private set; } = null;

    public RectTransform selectionBoxRect { get; private set; } = null;



    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag(Tag.MainCanvas).GetComponent<Canvas>();
        if (!canvas)
        {
            Debug.LogError("드래그 박스를 랜더링할 캔버스가 없음.");
        }

        GameManager.inputMappingContext.Player.LeftClick.performed += OnStartDragging;
        GameManager.inputMappingContext.Player.LeftClick.canceled += OnStopDragging;
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
        return selectionBoxRect.sizeDelta.x > 3f && selectionBoxRect.sizeDelta.y > 3f;
    }

    private void SelectUnits()
    {
        Vector2 min = new Vector2(
            Mathf.Min(startMousePos.x, currMousePos.x),
            Mathf.Min(startMousePos.y, currMousePos.y)
        );
        Vector2 max = new Vector2(
            Mathf.Max(startMousePos.x, currMousePos.x),
            Mathf.Max(startMousePos.y, currMousePos.y)
        );

        Collider2D[] colliders = Physics2D.OverlapAreaAll(min, max, selectableLayer);
        foreach (var collider in colliders)
        {
            GameObject unit = collider.gameObject;

            var selectables = unit.GetComponents<IObjectSelect>();
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
            unit.GetComponent<IObjectSelect>().OnSelect();
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
            var selectables = unit.GetComponents<IObjectSelect>();
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