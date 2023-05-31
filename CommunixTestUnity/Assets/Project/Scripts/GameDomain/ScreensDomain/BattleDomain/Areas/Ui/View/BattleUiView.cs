using System;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View;
using Project.Scripts.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View;
using UnityEngine;
using UnityEngine.UI;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.View
{
    public class BattleUiView : MonoBehaviour, IBattleUiView
    {
        public event Action MenuClicked;
        
        [SerializeField] private UiInputView _uiInputView;
        [SerializeField] private Button _menuButton;

        public IUiInputView InputView => _uiInputView;

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuClick);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuClick);
        }

        private void OnMenuClick()
        {
            MenuClicked?.Invoke();
        }
    }
}