using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.CoreDomain.Services.Screen;
using Project.GameDomain.Areas.Levels.Model;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Rule
{
    public class GameWonSystem : IUpdateSystem
    {
        private readonly IScreensService _screensService;
        private readonly ILevelsModel _levelsModel;
        private readonly IFilter _playerFilter;
        private readonly IFilter _enemyFilter;

        public GameWonSystem(IWorld world, IScreensService screensService, ILevelsModel levelsModel)
        {
            _screensService = screensService;
            _levelsModel = levelsModel;
            _playerFilter = world.GetFilter(matcher => matcher.Has<PlayerComponent>());
            _enemyFilter = world.GetFilter(matcher => matcher.Has<EnemyComponent>());
        }

        public void Update()
        {
            foreach (var _ in _playerFilter)
            {
                foreach (var enemy in _enemyFilter)
                {
                    return;
                }

                _levelsModel.CurrentLevel++;
                
                _screensService.SwitchAsync(BattleScreen.Id);
            }
        }
    }
}