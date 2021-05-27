using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool JumpButtonPressed { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        JumpButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JumpButtonPressed = false;
    }
}