using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;

namespace Project.GameDomain.ScreensDomain.MainDomain
{
    public class MainScreen : Screen<MainScreen>
    {
        protected override string ScreenId => Id;

        public static string Id => "MainScreen";
        public override bool IsDisposeOnSwitch => false;

        public override UniTask ShowAsync()
        {
            return UniTask.CompletedTask;
        }

        public override UniTask HideAsync()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask InitializeScreenAsync()
        {
            return UniTask.CompletedTask;
        }

        protected override UniTask DisposeScreenAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}