using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.GameDomain.ScreensDomain;
using Project.GameDomain.ScreensDomain.LoadingDomain;
using Project.GameDomain.ScreensDomain.SplashDomain;
using UnityEngine;
using Zenject;

namespace Project.GameDomain
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] [Dropdown(nameof(GetScreens) + "()")]
        private string _startScreen;

        private IScreenInitializable _screenInitializable;
        private IScreensService _screensService;

        public List<string> GetScreens() => ScreensIds.Ids;

        [Inject]
        private void Construct(
            IScreenInitializable screenInitializable,
            IScreensService screensService
        )
        {
            _screenInitializable = screenInitializable;
            _screensService = screensService;
        }

        private async void Start()
        {
            Application.targetFrameRate = 300;
            _screenInitializable.SetSplashScreen(SplashScreen.Id);
            _screenInitializable.SetLoadingScreen(LoadingScreen.Id);
            await _screensService.SwitchAsync(SplashScreen.Id);
            _screensService.SwitchAsync(_startScreen).Forget();
        }
    }
}