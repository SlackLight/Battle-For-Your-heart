using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class OnMouseClick : MonoBehaviour, IPointerDownHandler
{

    public UnityEvent OnMouse;



    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }


    void OnMouseDown()
    {
        OnMouse.Invoke();
    }
    
}
