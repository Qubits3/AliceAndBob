using Input;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonInput : ButtonInput
{
    public bool RightButtonPressed { get; private set; }

    public override void OnPointerDown(PointerEventData eventData)
    {
        RightButtonPressed = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        RightButtonPressed = false;
    }
}