using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Osyacat.Ecs.System;
using Project.CoreDomain;
using Project.CoreDomain.Services.Engine;
using Project.CoreDomain.Services.Screen;

namespace Project.GameDomain.ScreensDomain.BattleDomain
{
    public class BattleScreen : Screen<BattleScreen>
    {
        private readonly List<IPresenter> _presenters;
        private readonly ISystems _systems;
        private readonly IEngineService _engineService;
        protected override string ScreenId => Id;

        public static string Id => "BattleScreen";
        public override bool IsDisposeOnSwitch => true;

        public BattleScreen(
            List<IPresenter> presenters,
            ISystems systems,
            IEngineService engineService
        )
        {
            _presenters = presenters;
            _systems = systems;
            _engineService = engineService;
        }

        public override UniTask ShowAsync()
        {
            AddListeners();
            _systems.Initialize();
            return UniTask.CompletedTask;
        }

        public override UniTask HideAsync()
        {
            RemoveListeners();
            _systems.Destroy();
            return UniTask.CompletedTask;
        }

        protected override async UniTask InitializeScreenAsync()
        {
            foreach (var presenter in _presenters)
            {
                await presenter.InitializeAsync();
            }
        }

        protected override async UniTask DisposeScreenAsync()
        {
            foreach (var presenter in _presenters)
            {
                await presenter.DisposeAsync();
            }
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
            _systems.BeforeUpdate();
            _systems.Update();
            _systems.LateUpdate();
        }

        private void OnFixedUpdating()
        {
            _systems.FixedUpdate();
        }
    }
}