using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IDragHandler, IDropHandler
{

    [HideInInspector]
    public RectTransform rect;
    public Vector2 lastPosition;

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData)
    {
        lastPosition = rect.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        lastPosition = rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
