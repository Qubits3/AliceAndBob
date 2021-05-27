using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool LeftButtonPressed { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        LeftButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeftButtonPressed = false;
    }
}