using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Content;
using Project.CoreDomain.Services.Engine;
using Project.CoreDomain.Services.Screen;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain
{
    public class BattleScreen : Screen<BattleScreen>
    {
        private readonly IContentService _contentService;
        private readonly IEngineService _engineService;
        protected override string ScreenId => Id;

        public static string Id => "BattleScreen";
        public override bool IsDisposeOnSwitch => false;

        public BattleScreen(
            IContentService contentService,
            IEngineService engineService
        )
        {
            _contentService = contentService;
            _engineService = engineService;
        }

        public override UniTask ShowAsync()
        {
            AddListeners();
            
            return UniTask.CompletedTask;
        }

        public override UniTask HideAsync()
        {
            RemoveListeners();
            
            return UniTask.CompletedTask;
        }

        protected override async UniTask InitializeScreenAsync()
        {
            _disposables.Push(await _contentService.LoadAsync<GameObject>(BattleScreenContentIds.PlayerPrefab));
            _disposables.Push(await _contentService.LoadAsync<GameObject>(BattleScreenContentIds.EnemyPrefab));
        }

        protected override UniTask DisposeScreenAsync()
        {
            return UniTask.CompletedTask;
        }

        private void AddListeners()
        {
            _engineService.Updating += OnUpdating;
            _engineService.FixedUpdating += OnFixedUpdating;
        }

        private void RemoveListeners()
        {
            _engineService.Updating -= OnUpdating;
            _engineService.FixedUpdating -= OnFixedUpdating;
        }

        private void OnUpdating()
        {
        }

        private void OnFixedUpdating()
        {
        }
    }
}