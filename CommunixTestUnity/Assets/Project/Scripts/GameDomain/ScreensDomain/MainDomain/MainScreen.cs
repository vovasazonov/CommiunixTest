using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Screen;

namespace Project.GameDomain.ScreensDomain.MainDomain
{
    public class MainScreen : Screen<MainScreen>
    {
        private readonly List<IPresenter> _presenters;
        protected override string ScreenId => Id;

        public static string Id => "MainScreen";
        public override bool IsDisposeOnSwitch => false;

        public MainScreen(List<IPresenter> presenters)
        {
            _presenters = presenters;
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
    }
}