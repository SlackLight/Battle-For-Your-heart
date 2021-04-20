using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool winItem = false;

    [SerializeField]
    private Canvas canvas;

    private RectTransform rectTransform;

    private PolygonCollider2D collider;

    private void Start()
    {
        canvas = GameObject.Find("MatchingCanvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        collider = GetComponent<PolygonCollider2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        MatchingTest.currentlyPressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //follow mouse position until end
        //Vector3 mouse = Camera.main.ScreenToWorldPoint(eventData.delta);

        //transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor / 100;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MatchingTest.currentlyPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

}
