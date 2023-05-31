using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.GameDomain.Areas.Levels.Model;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.Presenter;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Multiplayer.Model;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.View
{
    public class MenuPresenter : IPresenter
    {
        private readonly IViewService _viewService;
        private readonly ILevelsModel _levelsModel;
        private readonly IScreensService _screensService;
        private readonly IMultiplayerModel _multiplayerModel;
        private IDisposableView<IMenuView> _view;
        private IPresenter _levelsPresenter;

        public MenuPresenter(
            IViewService viewService,
            ILevelsModel levelsModel,
            IScreensService screensService,
            IMultiplayerModel multiplayerModel
        )
        {
            _viewService = viewService;
            _levelsModel = levelsModel;
            _screensService = screensService;
            _multiplayerModel = multiplayerModel;
        }

        public async UniTask InitializeAsync()
        {
            _view = await _viewService.CreateAsync<MenuView>(MainScreenContentIds.MenuPrefab);
            _view.Value.PlayClicked += OnPlayClicked;
            _view.Value.MultiplayerChanged += OnMultiplayerChanged;
            _levelsPresenter = new LevelsPresenter(_view.Value.Levels, _levelsModel, _screensService);
            await _levelsPresenter.InitializeAsync();
        }

        public async UniTask DisposeAsync()
        {
            _view.Value.PlayClicked -= OnPlayClicked;
            _view.Value.MultiplayerChanged -= OnMultiplayerChanged;
            _view.Dispose();
            await _levelsPresenter.DisposeAsync();
        }

        private void OnMultiplayerChanged(bool isMultiplayer)
        {
            _multiplayerModel.IsMultiplayer = isMultiplayer;
        }

        private void OnPlayClicked()
        {
            _screensService.SwitchAsync("BattleScreen");
        }
    }
}