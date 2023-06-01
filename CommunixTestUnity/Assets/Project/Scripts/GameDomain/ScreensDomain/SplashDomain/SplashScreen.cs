using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Content;
using Project.CoreDomain.Services.Screen;
using Project.GameDomain.ScreensDomain.BattleDomain;
using Project.GameDomain.ScreensDomain.MainDomain;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.SplashDomain
{
    public class SplashScreen : Screen<SplashScreen>
    {
        private readonly List<ITaskAsyncInitializable> _initializables;
        private readonly IContentService _contentService;

        protected override string ScreenId => Id;

        public static string Id => "SplashScreen";
        public override bool IsDisposeOnSwitch => true;

        public SplashScreen(List<ITaskAsyncInitializable> initializables, IContentService contentService)
        {
            _initializables = initializables;
            _contentService = contentService;
        }

        public override UniTask ShowAsync()
        {
            return UniTask.CompletedTask;
        }

        public override UniTask HideAsync()
        {
            return UniTask.CompletedTask;
        }

        protected override async UniTask InitializeScreenAsync()
        {
            foreach (var initializable in _initializables)
            {
                await initializable.InitializeAsync();
            }

            var contents = new List<UniTask>
            {
                _contentService.LoadAsync<GameObject>(MainScreenContentIds.MenuPrefab),
                _contentService.LoadAsync<GameObject>(BattleScreenContentIds.BattlePrefab),
                _contentService.LoadAsync<GameObject>(BattleScreenContentIds.UiPrefab)
            };

            await UniTask.WhenAll(contents);
        }

        protected override UniTask DisposeScreenAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}