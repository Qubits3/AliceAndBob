using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool RightButtonPressed { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        RightButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RightButtonPressed = false;
    }
}