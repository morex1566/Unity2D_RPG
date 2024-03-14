using System.Collections.Generic;
using UnityEngine;

public class AIPerception : MonoBehaviour
{
    [Tooltip("인식 범위")]
    [SerializeField] private Collider2D range;

    [Tooltip("인식 가능 대상의 레이어")]
    [SerializeField] private List<LayerMask> perceptionTargetLayers = new List<LayerMask>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var layer in perceptionTargetLayers)
        {
            if ((collision.gameObject.layer & layer) != 0)
            {
                Debug.Log($"{collision.gameObject.name} triggered");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var layer in perceptionTargetLayers)
        {
            if ((collision.gameObject.layer & layer) != 0)
            {
                Debug.Log($"{collision.gameObject.name} triggered");
            }
        }
    }
}
