using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Input.Model
{
    public class InputModel : IInputModel
    {
        public PlayerInput Player1 { get; } = new()
        {
            Fire = KeyCode.Space,
            Left = KeyCode.LeftArrow,
            Right = KeyCode.RightArrow
        };
        
        public PlayerInput Player2 { get; } = new()
        {
            Fire = KeyCode.W,
            Left = KeyCode.A,
            Right = KeyCode.D
        };
    }
}