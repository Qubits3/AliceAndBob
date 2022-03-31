using UnityEngine.EventSystems;

namespace Input
{
    public class LeftButtonInput : ButtonInput
    {
        public bool LeftButtonPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            LeftButtonPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            LeftButtonPressed = false;
        }
    }
}