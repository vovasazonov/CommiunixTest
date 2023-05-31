using System;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View;
using UnityEngine;
using UnityEngine.UI;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.View
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        public event Action PlayClicked;
        public event Action<bool> MultiplayerChanged;

        [SerializeField] private LevelsView _levelsView;
        [SerializeField] private Button _playButton;
        [SerializeField] private Toggle _multiplayerToggle;

        public ILevelsView Levels => _levelsView;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayClick);
            _multiplayerToggle.onValueChanged.AddListener(OnMultiplayerChanged);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClick);
            _multiplayerToggle.onValueChanged.RemoveListener(OnMultiplayerChanged);
        }

        private void OnMultiplayerChanged(bool isMultiplayer)
        {
            MultiplayerChanged?.Invoke(isMultiplayer);
        }

        private void OnPlayClick()
        {
            PlayClicked?.Invoke();
        }
    }
}