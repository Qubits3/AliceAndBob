using UnityEngine.EventSystems;

namespace Input
{
    public class JumpButtonInput : ButtonInput
    {
        public bool JumpButtonPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            JumpButtonPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            JumpButtonPressed = false;
        }
    }
}