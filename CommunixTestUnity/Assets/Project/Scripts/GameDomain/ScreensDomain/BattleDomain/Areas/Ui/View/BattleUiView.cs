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
        [SerializeField] private Button _menuGameOverButton;
        [SerializeField] private GameObject _gameOverPopup;

        public IUiInputView InputView => _uiInputView;
        
        public void SetActiveGameOver(bool isActive)
        {
            _gameOverPopup.SetActive(isActive);
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuClick);
            _menuGameOverButton.onClick.AddListener(OnMenuClick);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuClick);
            _menuGameOverButton.onClick.RemoveListener(OnMenuClick);
        }

        private void OnMenuClick()
        {
            MenuClicked?.Invoke();
        }
    }
}