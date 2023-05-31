using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.View;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.View
{
    public class MenuPresenter : IPresenter
    {
        private readonly IViewService _viewService;
        private IDisposableView<MenuView> _view;

        public MenuPresenter(IViewService viewService)
        {
            _viewService = viewService;
        }

        public async UniTask InitializeAsync()
        {
            _view = await _viewService.CreateAsync<MenuView>(MainScreenContentIds.MenuPrefab);
        }

        public UniTask DisposeAsync()
        {
            _view.Dispose();
            
            return UniTask.CompletedTask;
        }
    }
}