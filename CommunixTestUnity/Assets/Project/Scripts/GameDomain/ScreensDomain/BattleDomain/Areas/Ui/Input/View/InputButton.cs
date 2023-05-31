using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View
{
    internal class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsInput;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            IsInput = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsInput = false;
        }
    }
}