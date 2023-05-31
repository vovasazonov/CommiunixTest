using System;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View;
using UnityEngine;
using UnityEngine.UI;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.View
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        public event Action PlayClicked;
        
        [SerializeField] private LevelsView _levelsView;
        [SerializeField] private Button _playButton;

        public ILevelsView Levels => _levelsView;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayClick);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClick);
        }

        private void OnPlayClick()
        {
            PlayClicked?.Invoke();
        }
    }
}