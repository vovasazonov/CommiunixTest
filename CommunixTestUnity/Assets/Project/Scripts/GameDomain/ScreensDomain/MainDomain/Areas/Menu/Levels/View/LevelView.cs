using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View
{
    public class LevelView : MonoBehaviour
    {
        public event Action<int> Clicked;
        
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Button _button;
        private int _level;

        public void SetLevel(int level)
        {
            _level = level;
            _levelText.text = level.ToString();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke(_level);
        }
    }
}