using Osyacat.Ecs.Entity;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Multiplayer.Model;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player
{
    public class MultiplayerInitializerSystem : IUpdateSystem
    {
        private readonly IMultiplayerModel _multiplayerModel;
        private readonly IFilter _playerFilter;
        private bool _isInitialized;

        public MultiplayerInitializerSystem(IWorld world, IMultiplayerModel multiplayerModel)
        {
            _multiplayerModel = multiplayerModel;
            _playerFilter = world.GetFilter(matcher => matcher.Has<PlayerComponent>());
        }

        public void Update()
        {
            if (_isInitialized)
            {
                return;
            }
            
            foreach (var player in _playerFilter.GetEntities())
            {
                _isInitialized = true;
                var id = player.Get<PlayerComponent>().Id;

                if (id == 2 && !_multiplayerModel.IsMultiplayer)
                {
                    var view = player.Get<ViewComponent>().Value;
                    Object.DestroyImmediate(((EntityView)view).gameObject);
                    player.Destroy();
                }
            }
        }
    }
}