using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View
{
    public class UiInputView : MonoBehaviour, IUiInputView
    {
        [SerializeField] private GameObject _player1InputContainer;
        [SerializeField] private InputButton _leftPlayer1Button;
        [SerializeField] private InputButton _rightPlayer1Button;
        [SerializeField] private InputButton _firePlayer1Button;

        [SerializeField] private GameObject _player2InputContainer;
        [SerializeField] private InputButton _leftPlayer2Button;
        [SerializeField] private InputButton _rightPlayer2Button;
        [SerializeField] private InputButton _firePlayer2Button;

        public bool IsPlayer1Active
        {
            set => _player1InputContainer.SetActive(value);
        }

        public bool IsPlayer2Active
        {
            set => _player2InputContainer.SetActive(value);
        }

        public bool IsLeftPlayer1 => _leftPlayer1Button.IsInput;
        public bool IsRightPlayer1 => _rightPlayer1Button.IsInput;
        public bool IsFirePlayer1 => _firePlayer1Button.IsInput;
        public bool IsLeftPlayer2 => _leftPlayer2Button.IsInput;
        public bool IsRightPlayer2 => _rightPlayer2Button.IsInput;
        public bool IsFirePlayer2 => _firePlayer2Button.IsInput;
    }
}