using Project.CoreDomain.Services.Engine;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Input.Model
{
    public class PlayerInput
    {
        public KeyCode Left;
        public KeyCode Right;
        public KeyCode Fire;

        public bool IsLeft;
        public bool IsRight;
        public bool IsFire;

        public PlayerInput(IEngineService engineService)
        {
            engineService.Updating += () =>
            {
                IsLeft = UnityEngine.Input.GetKey(Left);
                IsRight = UnityEngine.Input.GetKey(Right);
                IsFire = UnityEngine.Input.GetKeyDown(Fire);
            };
        }
    }
}