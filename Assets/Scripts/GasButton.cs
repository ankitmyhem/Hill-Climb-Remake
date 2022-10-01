using UnityEngine;
using UnityEngine.EventSystems;

public class GasButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        CarController.instance.isMovingForward = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        CarController.instance.isMovingForward = false;
    }
}
