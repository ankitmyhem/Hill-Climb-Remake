using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    public void OnPointerDown(PointerEventData data)
    {
        CarController.instance.isMovingBackward = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        CarController.instance.isMovingBackward = false;
    }
}
