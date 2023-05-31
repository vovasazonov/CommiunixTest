using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View
{
    public class LevelsView : MonoBehaviour, ILevelsView
    {
        public event Action<int> LevelClicked;

        [SerializeField] private LevelView _levelViewPrefab;
        [SerializeField] private GameObject _levelParent;
        private readonly List<LevelView> _views = new();

        public void Initialize(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                int level = i + 1;
                var view = Instantiate(_levelViewPrefab, _levelParent.transform);
                view.SetLevel(level);
                view.Clicked += OnClicked;
            }
        }

        private void OnDestroy()
        {
            foreach (var view in _views)
            {
                view.Clicked -= OnClicked;
            }
        }

        private void OnClicked(int level)
        {
            LevelClicked?.Invoke(level);
        }
    }
}