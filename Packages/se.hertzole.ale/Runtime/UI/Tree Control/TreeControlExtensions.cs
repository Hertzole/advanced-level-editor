using UnityEngine;
using UnityEngine.EventSystems;

namespace Hertzole.ALE
{
    public static class TreeControlExtensions
    {
        //TODO: Hook into new input system.
        public static bool IsPointerValid(this PointerEventData eventData)
        {
            for (int i = Input.touchCount - 1; i >= 0; i--)
            {
                if (Input.GetTouch(i).fingerId == eventData.pointerId)
                {
                    return true;
                }
            }

            return Input.GetMouseButton((int)eventData.button);
        }
    }
}
