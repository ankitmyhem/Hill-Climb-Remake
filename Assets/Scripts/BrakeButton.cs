using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    public void OnPointerDown(PointerEventData data)
    {
        GameObject.FindObjectOfType<CarController>().isMovingBackward = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        GameObject.FindObjectOfType<CarController>().isMovingBackward = false;
    }
}
