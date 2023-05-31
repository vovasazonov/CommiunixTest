using Project.CoreDomain.Services.Engine;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Input.Model
{
    public class InputModel : IInputModel
    {
        public PlayerInput Player1 { get; }
        public PlayerInput Player2 { get; }

        public InputModel(IEngineService engineService)
        {
            Player1 = new(engineService)
            {
                Fire = KeyCode.Space,
                Left = KeyCode.LeftArrow,
                Right = KeyCode.RightArrow
            };

            Player2 = new(engineService)
            {
                Fire = KeyCode.W,
                Left = KeyCode.A,
                Right = KeyCode.D
            };
        }
    }
}