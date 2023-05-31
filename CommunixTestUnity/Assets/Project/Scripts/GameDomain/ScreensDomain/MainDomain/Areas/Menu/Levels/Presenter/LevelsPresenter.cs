using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Screen;
using Project.GameDomain.Areas.Levels.Model;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.Presenter
{
    public class LevelsPresenter : IPresenter
    {
        private readonly ILevelsView _view;
        private readonly ILevelsModel _levelsModel;
        private readonly IScreensService _screensService;

        public LevelsPresenter(ILevelsView view, ILevelsModel levelsModel, IScreensService screensService)
        {
            _view = view;
            _levelsModel = levelsModel;
            _screensService = screensService;
        }

        public UniTask InitializeAsync()
        {
            _view.Initialize(_levelsModel.TotalLevels);
            _view.LevelClicked += OnLevelClicked;
            
            return UniTask.CompletedTask;
        }

        public UniTask DisposeAsync()
        {
            _view.LevelClicked -= OnLevelClicked;
            
            return UniTask.CompletedTask;
        }

        private void OnLevelClicked(int level)
        {
            _levelsModel.CurrentLevel = level;
            _screensService.SwitchAsync("BattleScreen");
        }
    }
}