using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.View;
using Project.GameDomain.Areas.Levels.Model;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.View;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Presenter
{
    public class BattlePresenter : IPresenter
    {
        private readonly IViewService _viewService;
        private readonly ILevelsModel _levelsModel;
        private IDisposableView<BattleView> _view;

        public BattlePresenter(IViewService viewService, ILevelsModel levelsModel)
        {
            _viewService = viewService;
            _levelsModel = levelsModel;
        }

        public async UniTask InitializeAsync()
        {
            _view = await _viewService.CreateAsync<BattleView>($"Assets/Project/Content/GameDomain/ScreensDomain/BattleDomain/Prefabs/Levels/Level{_levelsModel.CurrentLevel}.prefab");
        }

        public UniTask DisposeAsync()
        {
            _view.Dispose();
            return UniTask.CompletedTask;
        }
    }
}