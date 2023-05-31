using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Engine;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.Presenter;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.View;
using Project.GameDomain.ScreensDomain.MainDomain;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Multiplayer.Model;
using Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Input.Model;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Presenter
{
    public class BattleUiPresenter : IPresenter
    {
        private readonly IViewService _viewService;
        private readonly IScreensService _screensService;
        private readonly IEngineService _engineService;
        private readonly IMultiplayerModel _multiplayerModel;
        private readonly IInputModel _inputModel;
        private IDisposableView<IBattleUiView> _view;
        private IPresenter _inputPresenter;

        public BattleUiPresenter(
            IViewService viewService,
            IScreensService screensService,
            IEngineService engineService,
            IMultiplayerModel multiplayerModel,
            IInputModel inputModel
        )
        {
            _viewService = viewService;
            _screensService = screensService;
            _engineService = engineService;
            _multiplayerModel = multiplayerModel;
            _inputModel = inputModel;
        }

        public async UniTask InitializeAsync()
        {
            _view = await _viewService.CreateAsync<BattleUiView>(BattleScreenContentIds.UiPrefab);
            _view.Value.MenuClicked += OnMenuClicked;
            _inputPresenter = new UiInputPresenter(_engineService, _multiplayerModel, _view.Value.InputView, _inputModel);
            await _inputPresenter.InitializeAsync();
        }

        public async UniTask DisposeAsync()
        {
            _view.Value.MenuClicked -= OnMenuClicked;
            _view.Dispose();
            await _inputPresenter.DisposeAsync();
        }

        private void OnMenuClicked()
        {
            _screensService.SwitchAsync(MainScreen.Id);
        }
    }
}