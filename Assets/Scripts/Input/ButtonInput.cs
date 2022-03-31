using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public abstract class ButtonInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public abstract void OnPointerDown(PointerEventData eventData);

        public abstract void OnPointerUp(PointerEventData eventData);
    }
}