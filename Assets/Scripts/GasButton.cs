using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GasButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        GameObject.FindObjectOfType<CarController>().isMovingForward = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        GameObject.FindObjectOfType<CarController>().isMovingForward = false;
    }
}
